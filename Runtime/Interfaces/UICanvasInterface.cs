using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI.Interfaces
{
    public class UICanvasInterface : UIInterface<SO_UIStyleCanvas>, IUICanvas
    {
        [SerializeField] private Canvas       _canvas;
        [SerializeField] private CanvasScaler _canvasScaler;
        
        public void UpdateAllChildren()
        {
            UIInterface[] uiInterfaces = GetComponentsInChildren<UIInterface>();
            foreach (UIInterface uiInterface in uiInterfaces) { uiInterface.AssignRootCanvasInterface(this); }
        }

        public RenderMode RenderMode => Style.RenderMode;
        
        public float ReferencePixelsPerUnit => Style.ReferencePixelPerUnit;

        protected override void ApplyStyle()
        {
            base.ApplyStyle();
            
            Style.Apply(_canvas, _canvasScaler);
        }

        protected override void OnStyleApply() { UpdateAllChildren(); }
    }
}