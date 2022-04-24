using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Scripts.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI.Scripts.Interfaces
{
    public class UICanvasInterface : UIInterface<SO_UIStyleCanvas>
    {
        [SerializeField] private Canvas       _canvas;
        [SerializeField] private CanvasScaler _canvasScaler;

        protected override void ApplyStyle() { Style.Apply(_canvas, _canvasScaler); }

        protected override void OnStyleApply() { UpdateAllChildren(); }

        public void UpdateAllChildren()
        {
            UIInterface[] uiInterfaces = GetComponentsInChildren<UIInterface>();
            foreach (UIInterface uiInterface in uiInterfaces) { uiInterface.AssignRootCanvasInterface(this); }
        }
    }
}