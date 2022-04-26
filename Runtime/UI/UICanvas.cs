using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Interfaces;
using WinuXGames.SplitFramework.UI.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI.UI
{
    public class UICanvas : UIBase<SO_UIStyleCanvas>, IUICanvas
    {
        [SerializeField] private Canvas       _canvas;
        [SerializeField] private CanvasScaler _canvasScaler;
        
        public Canvas       Canvas                 => _canvas;
        public CanvasScaler CanvasScaler           => _canvasScaler;
        public RenderMode   RenderMode             => Style.RenderMode;
        public float        ReferencePixelsPerUnit => Style.ReferencePixelPerUnit;
        

        public void UpdateAllChildren()
        {
            UIBase[] uiInterfaces = GetComponentsInChildren<UIBase>();
            foreach (UIBase uiInterface in uiInterfaces) { uiInterface.AssignRootCanvasInterface(this); }
        }


        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            Style.Apply(this);
        }

        protected override void OnStyleApply() { UpdateAllChildren(); }
    }
}