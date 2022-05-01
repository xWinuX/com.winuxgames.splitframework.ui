using UnityEngine;
using WinuXGames.SplitFramework.UI.Interfaces;
using WinuXGames.SplitFramework.UI.ScriptableObjects;
using WinuXGames.SplitFramework.UI.ScriptableObjects.Styles;

namespace WinuXGames.SplitFramework.UI.UI.Core
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIBase : MonoBehaviour, IUI
    {
        public RectTransform RectTransform { get; private set; }
        public IUICanvas     RootUICanvas  { get; private set; } = new UICanvasMock();

        protected virtual void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
        }

        private void OnValidate()
        {
            GetRootCanvasInterface();
            ApplyStyle();
            OnStyleApply();
        }

        public void AssignRootCanvas(IUICanvas canvasInterface)
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
            else { RootUICanvas              = new UICanvasMock(); }
        }

        protected virtual void ApplyStyle() { }

        protected virtual void OnStyleApply() { }

        protected T InstantiateWithRootCanvas<T>(T prefab) where T : UIBase => Instantiate(prefab, RootUICanvas);
        protected T InstantiateWithRootCanvas<T>(T prefab, Transform parent) where T : UIBase => Instantiate(prefab, parent, RootUICanvas);

        public static T Instantiate<T>(T prefab, IUICanvas rootCanvas) where T : UIBase
        {
            T obj = Instantiate(prefab);
            obj.AssignRootCanvas(rootCanvas);
            return obj;
        }
        
        public static T Instantiate<T>(T prefab, Transform parent, IUICanvas rootCanvas) where T : UIBase
        {
            T obj = Instantiate(prefab, parent);
            obj.AssignRootCanvas(rootCanvas);
            return obj;
        }
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