using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Core;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Elements.Styles;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public class UICanvas : UIBaseWithStyle<SO_UIStyleCanvas>, ICanvas
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
            foreach (UIBase uiInterface in uiInterfaces) { uiInterface.AssignRootCanvas(this); }
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            Style.Apply(this);
        }

        protected override void OnStyleApply() { UpdateAllChildren(); }
    }
}