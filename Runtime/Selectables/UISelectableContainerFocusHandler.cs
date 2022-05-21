using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Providers;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Selectables
{
    [RequireComponent(typeof(ISelectablesContainer))]
    public class UISelectableContainerFocusHandler : MonoBehaviour
    {
        [SerializeField] private SO_UIDependencyProvider _uiDependency;
        [SerializeField] private GameObject              _selectableContainerGameObject;
        [SerializeField] private int                     _position;
        [SerializeField] private UISelectorBase          _selectorPrefab;

        private ISelectablesContainer _selectablesContainer;

        private void Start() { _uiDependency.SelectableManager.SetSelectableContainer(_selectablesContainer, _position, _selectorPrefab); }

        private void OnValidate()
        {
            _selectablesContainer = null;
            if (_selectableContainerGameObject == null) { return; }

            ISelectablesContainer selectablesContainer = _selectableContainerGameObject.GetComponent<ISelectablesContainer>();

            if (selectablesContainer != null)
            {
                _selectablesContainer = selectablesContainer;
                return;
            }

            _selectableContainerGameObject = null;
            Debug.LogError("Assigned GameObject has no component that implements ISelectableContainer");
        }
    }
}