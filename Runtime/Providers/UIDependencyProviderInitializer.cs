using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using WinuXGames.SplitFramework.UI.Core;

namespace WinuXGames.SplitFramework.UI.Providers
{
    public class UIDependencyProviderInitializer : MonoBehaviour
    {
        [SerializeField] private EventSystem              _eventSystem;
        [SerializeField] private InputSystemUIInputModule _inputModule;
        [SerializeField] private SelectableManager        _selectableManager;

        [SerializeField] private SO_UIDependencyProvider _uiDependencyProvider;

        private void Awake()
        {
            _uiDependencyProvider.AssignEventSystem(_eventSystem);
            _uiDependencyProvider.AssignInputModule(_inputModule);
            _uiDependencyProvider.AssignSelectableManager(_selectableManager);
        }
    }
}