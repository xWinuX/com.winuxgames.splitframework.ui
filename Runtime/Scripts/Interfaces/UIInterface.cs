using UnityEngine;
using WinuXGames.SplitFramework.UI.Scripts.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI.Scripts.Interfaces
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIInterface : MonoBehaviour
    {
        public RectTransform     RectTransform       { get; private set; }
        public UICanvasInterface RootCanvasInterface { get; private set; }

        protected virtual void Awake() { RectTransform = GetComponent<RectTransform>(); }

        private void OnValidate()
        {
            if (RootCanvasInterface == null)
            {
                UICanvasInterface canvasInterface = GetRootCanvasInterface();
                if (canvasInterface != null) { RootCanvasInterface = canvasInterface; }
                else
                {
                    if (GetType() == typeof(UICanvasInterface)) { RootCanvasInterface = (UICanvasInterface)this; }
                    else { Debug.LogError("UI elements root canvas has no interface!"); }
                }
            }

            ApplyStyle();
            OnStyleApply();
        }

        public void AssignRootCanvasInterface(UICanvasInterface canvasInterface)
        {
            RootCanvasInterface = canvasInterface;
            ApplyStyle();
        }

        private UICanvasInterface GetRootCanvasInterface()
        {
            int               safetyExit = 100;
            Transform         parent     = transform.parent;
            UICanvasInterface root       = null;
            while (parent != null && safetyExit > 0)
            {
                UICanvasInterface canvasInterface = parent.GetComponent<UICanvasInterface>();
                if (canvasInterface != null) { root = canvasInterface; }

                parent = parent.parent;

                safetyExit--;
            }

            return root;
        }

        protected abstract void ApplyStyle();

        protected virtual void OnStyleApply() { }
    }


    public abstract class UIInterface<TStyle> : UIInterface where TStyle : SO_UIStyle
    {
        [SerializeField] private TStyle _style;

        public TStyle Style => _style;
    }
}