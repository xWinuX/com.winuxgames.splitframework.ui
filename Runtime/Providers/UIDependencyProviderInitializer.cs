using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using WinuXGames.SplitFramework.Core.Providers;
using WinuXGames.SplitFramework.UI.Core;

namespace WinuXGames.SplitFramework.UI.Providers
{
    [DefaultExecutionOrder(-1)]
    public class UIDependencyProviderInitializer : ScriptableProviderInitializer<SO_UIDependencyProvider>
    {
        [SerializeField] private EventSystem              _eventSystem;
        [SerializeField] private InputSystemUIInputModule _inputModule;
        [SerializeField] private SelectableManager        _selectableManager;
        
        private void Awake()
        {
            ProviderToInitialize.EventSystem = _eventSystem;
            ProviderToInitialize.InputModule = _inputModule;
            ProviderToInitialize.SelectableManager = _selectableManager;
        }
    }
}