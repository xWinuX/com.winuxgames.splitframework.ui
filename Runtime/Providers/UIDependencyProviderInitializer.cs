using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

namespace WinuXGames.SplitFramework.UI.Providers
{
    public class UIDependencyProviderInitializer : MonoBehaviour
    {
        [SerializeField] private EventSystem              _eventSystem;
        [SerializeField] private InputSystemUIInputModule _inputModule;
        [SerializeField] private SO_UIDependencyProvider  _uiDependencyProvider;

        private void Awake()
        {
            _uiDependencyProvider.AssignEventSystem(_eventSystem);
            _uiDependencyProvider.AssignInputModule(_inputModule);
        }
    }
}