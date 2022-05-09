using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using WinuXGames.SplitFramework.Core.Providers;
using WinuXGames.SplitFramework.UI.Core;

namespace WinuXGames.SplitFramework.UI.Providers
{
    [CreateAssetMenu(menuName = "Split Framework/Providers/EventSystem", fileName = "UIDependencyProvider", order = 0)]
    public class SO_UIDependencyProvider : SO_ScriptableProvider
    {
        public EventSystem              EventSystem       { get; internal set; }
        public InputSystemUIInputModule InputModule       { get; internal set; }
        public SelectableManager        SelectableManager { get; internal set; }
        
        protected override void ResetValues()
        {
            EventSystem       = null;
            InputModule       = null;
            SelectableManager = null;
        }
    }
}