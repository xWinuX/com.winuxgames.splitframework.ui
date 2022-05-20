using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements;
using WinuXGames.SplitFramework.UI.Elements.Core;

namespace WinuXGames.SplitFramework.UI.Core
{
    public abstract class SelectableContainerValidator : MonoBehaviour
    {
        [SerializeField] private GameObject _selectables;

        protected ISelectablesContainer SelectablesContainer;
        
        protected virtual void OnValidate()
        {
            if (_selectables == null) { return; }

            ISelectablesContainer container = _selectables.GetComponent<ISelectablesContainer>();

            if (container != null) { SelectablesContainer = container; }
            else
            {
                _selectables = null;
                Debug.LogWarning("Assigned GameObject has no component with interface ISelectableContainer!");
            }
        }
    }
}