using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using WinuXGames.SplitFramework.Core.Providers;

namespace WinuXGames.SplitFramework.UI.Providers
{
    [CreateAssetMenu(menuName = "Split Framework/Providers/EventSystem", fileName = "EventSystemProvider", order = 0)]
    public class SO_UIDependencyProvider : SO_ScriptableProvider
    {
        public EventSystem              EventSystem { get; private set; }
        public InputSystemUIInputModule InputModule { get; private set; }

        public void AssignEventSystem(EventSystem              eventSystem) { EventSystem = eventSystem; }
        public void AssignInputModule(InputSystemUIInputModule inputModule) { InputModule = inputModule; }

        protected override void ResetValues()
        {
            EventSystem = null;
            InputModule = null;
        }
    }
}