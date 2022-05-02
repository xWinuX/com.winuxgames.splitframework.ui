using UnityEngine;
using WinuXGames.SplitFramework.UI.Core;

namespace WinuXGames.SplitFramework.UI.Elements.Core
{
    public abstract class UIBase : UIBehaviour
    {
        protected override void OnValidate()
        {
            base.OnValidate();
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
    }
}