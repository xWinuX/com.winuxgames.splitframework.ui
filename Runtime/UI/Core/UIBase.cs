using UnityEngine;
using WinuXGames.SplitFramework.UI.Interfaces;
using WinuXGames.SplitFramework.UI.ScriptableObjects.Styles;

namespace WinuXGames.SplitFramework.UI.UI.Core
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIBase : MonoBehaviour
    {
        public ICanvas       RootUICanvas  { get; protected set; } = new UICanvasMock();
        public RectTransform RectTransform { get; private set; }
        
        protected virtual void Awake() { RectTransform = GetComponent<RectTransform>(); }
        
        private void OnValidate()
        {
            GetRootCanvasInterface();
            ApplyStyle();
            OnStyleApply();
        }
        
        public void AssignRootCanvas(ICanvas canvasInterface)
        {
            RootUICanvas = canvasInterface;
            ApplyStyle();
        }
        
        protected virtual void ApplyStyle()   { }
        protected virtual void OnStyleApply() { }
        
        protected T InstantiateWithRootCanvas<T>(T prefab, Transform parent) where T : UIBase => Instantiate(prefab, parent, RootUICanvas);

        public static T Instantiate<T>(T prefab, ICanvas rootCanvas) where T : UIBase
        {
            T obj = Instantiate(prefab);
            obj.AssignRootCanvas(rootCanvas);
            return obj;
        }

        public static T Instantiate<T>(T prefab, Transform parent, ICanvas rootCanvas) where T : UIBase
        {
            T obj = Instantiate(prefab, parent);
            obj.AssignRootCanvas(rootCanvas);
            return obj;
        }
        
        private void GetRootCanvasInterface()
        {
            int       safetyExit = 100;
            Transform parent     = transform.parent;
            ICanvas   root       = null;
            while (parent != null && safetyExit > 0)
            {
                ICanvas canvasInterface = parent.GetComponent<ICanvas>();
                if (canvasInterface != null) { root = canvasInterface; }

                parent = parent.parent;

                safetyExit--;
            }

            RootUICanvas = root ?? new UICanvasMock();
        }
    }

    public abstract class UIBase<TStyle> : UIBase where TStyle : SO_UIStyle
    {
        [SerializeField] private TStyle             _style;
        
        public TStyle Style { get => _style; private set => _style = value; }

        public void SetStyle(TStyle style)
        {
            Style = style;
            ApplyStyle();
        }
    }
    
}