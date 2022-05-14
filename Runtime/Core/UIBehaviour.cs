using UnityEngine;
using WinuXGames.SplitFramework.UI.Utility;

namespace WinuXGames.SplitFramework.UI.Core
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIBehaviour : MonoBehaviour, IUIBehaviour
    {
        public bool          PixelSnap    { get; internal set; }
        public RectTransform RectTransform { get; private set; }
        public ICanvas       RootUICanvas  { get; protected set; } = new UICanvasMock();

        protected virtual void Awake() { RectTransform = GetComponent<RectTransform>(); }

        protected virtual void Update()
        {
            #if UNITY_EDITOR
            if (PixelSnap)
            {
                // Snap position
                Vector3 position = RectTransform.position;
                position               = new Vector3Int((int)position.x, (int)position.y, (int)position.z);
                RectTransform.position = position;

                // Snap size
                Vector2 size = RectTransform.sizeDelta;
                size                    = new Vector2Int((int)size.x, (int)size.y);
                RectTransform.sizeDelta = size;
            }
            #endif
        }

        protected virtual void OnValidate()
        {
            RectTransform = GetComponent<RectTransform>();
            
            ICanvas canvas = UIUtility.TryGetRootCanvas(gameObject);
            if (canvas != null) { RootUICanvas = canvas; }
        }
    }
}