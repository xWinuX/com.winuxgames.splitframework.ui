using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Providers;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Selectables
{
    [RequireComponent(typeof(ISelectablesContainer))]
    public class UISelectableFocusHandler : MonoBehaviour
    {
        [SerializeField] private SO_UIDependencyProvider _uiDependency;
        [SerializeField] private UISelectorBase          _selectorPrefab;

        private ISelectablesContainer _selectablesContainer;

        private void Awake() { _selectablesContainer = GetComponent<ISelectablesContainer>(); }

        private void Start() { _uiDependency.SelectableManager.SetSelectableContainer(_selectablesContainer, _selectorPrefab); }
    }
}