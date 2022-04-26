using UnityEngine;
using WinuXGames.SplitFramework.UI.Interfaces;
using WinuXGames.SplitFramework.UI.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI.UI
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIBase : MonoBehaviour, IUI
    {
        public RectTransform RectTransform { get; private set; }
        public IUICanvas     RootUICanvas  { get; private set; } = new UICanvasMock();

        protected virtual void Awake() { RectTransform = GetComponent<RectTransform>(); }

        private void OnValidate()
        {
            GetRootCanvasInterface();

            ApplyStyle();
            OnStyleApply();
        }

        public void AssignRootCanvasInterface(IUICanvas canvasInterface)
        {
            RootUICanvas = canvasInterface;
            ApplyStyle();
        }

        private void GetRootCanvasInterface()
        {
            int       safetyExit = 100;
            Transform parent     = transform.parent;
            IUICanvas root       = null;
            while (parent != null && safetyExit > 0)
            {
                IUICanvas canvasInterface = parent.GetComponent<IUICanvas>();
                if (canvasInterface != null) { root = canvasInterface; }

                parent = parent.parent;

                safetyExit--;
            }

            if (root != null) { RootUICanvas = root; }
            else
            {
                if (GetType() == typeof(UICanvas)) { RootUICanvas = (IUICanvas)this; }
                else
                {
                    RootUICanvas = new UICanvasMock();
                    Debug.LogWarning("UI elements root canvas has no interface, assigning mock...");
                }
            }
        }

        protected virtual void ApplyStyle()
        {
            if (RootUICanvas == null) { GetRootCanvasInterface(); }
        }

        protected virtual void OnStyleApply() { }
    }


    public abstract class UIBase<TStyle> : UIBase, IUI<TStyle> where TStyle : SO_UIStyle
    {
        [SerializeField] private TStyle _style;

        public TStyle Style { get => _style; private set => _style = value; }

        public void SetStyle(TStyle style)
        {
            Style = style;
            ApplyStyle();
        }
    }
}