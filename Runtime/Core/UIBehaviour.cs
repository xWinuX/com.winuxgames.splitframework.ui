using UnityEngine;
using WinuXGames.SplitFramework.UI.Utility;

namespace WinuXGames.SplitFramework.UI.Core
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIBehaviour : MonoBehaviour, IUIBehaviour
    {
        public RectTransform RectTransform { get; private set; }
        public ICanvas       RootUICanvas  { get; protected set; } = new UICanvasMock();

        protected virtual void Awake() { RectTransform = GetComponent<RectTransform>(); }

        protected virtual void OnValidate()
        {
            RectTransform = GetComponent<RectTransform>();
            
            ICanvas canvas = UIUtility.TryGetRootCanvas(gameObject);
            if (canvas != null) { RootUICanvas = canvas; }
        }
    }
}