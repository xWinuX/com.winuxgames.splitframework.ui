using UnityEngine;
using WinuXGames.SplitFramework.UI.Providers;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Core
{
    public class SelectableManagerUnityEventHandler : SelectableContainerValidator
    {
        [SerializeField] private SO_UIDependencyProvider _uiDependency;
        [SerializeField] private int                     _position;
        [SerializeField] private UISelectorBase          _selectorPrefab;

        public void SwitchContext() { _uiDependency.SelectableManager.AddSelectableContainer(SelectablesContainer, _position, _selectorPrefab); }

        public void GoBack() { _uiDependency.SelectableManager.GoBack(); }

        public void Block() { _uiDependency.SelectableManager.Block(); }

        public void Unblock() { _uiDependency.SelectableManager.Unblock(); }
    }
}