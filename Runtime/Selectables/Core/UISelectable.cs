using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Core;
using WinuXGames.SplitFramework.UI.Extensions;
using WinuXGames.SplitFramework.UI.Providers;
using WinuXGames.SplitFramework.UI.Utility;

namespace WinuXGames.SplitFramework.UI.Selectables.Core
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Selectable))]
    public abstract class UISelectable : MonoBehaviour, ISelectable, IUIBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField] private SO_UIDependencyProvider   _uiDependency;
        [SerializeField] private UnityEvent<BaseEventData> _onSelectUnityEvent;
        [SerializeField] private UnityEvent                _onSubmitUnityEvent;
        [SerializeField] private Navigation                _navigation;

        public UnityEvent                OnSubmitUnityEvent => _onSubmitUnityEvent;
        public UnityEvent<BaseEventData> OnSelectUnityEvent => _onSelectUnityEvent;

        public RectTransform RectTransform { get; protected set; }
        public ICanvas       RootUICanvas  { get; private set; } = new UICanvasMock();

        private Selectable _selectable;

        private bool _isSelected;

        protected virtual void Awake()
        {
            RootUICanvas  ??= UIUtility.GetRootCanvasOrDefault(gameObject);
            RectTransform =   GetComponent<RectTransform>();
        }

        protected virtual void Update()
        {
            if (
                _isSelected &&
                _uiDependency.InputModule.submit.action.WasPerformedThisFrame() &&
                !_uiDependency.SelectableManager.Blocked
            ) { _onSubmitUnityEvent.Invoke(); }
        }

        #if UNITY_EDITOR
        private void OnValidate()
        {
            _selectable           = GetComponent<Selectable>();
            _selectable.hideFlags = HideFlags.NotEditable | HideFlags.HideInInspector;
            RectTransform         = GetComponent<RectTransform>();
            RootUICanvas          = UIUtility.GetRootCanvasOrDefault(gameObject);
        }
        #endif

        #if UNITY_EDITOR
        private void Reset() { _selectable.hideFlags = HideFlags.NotEditable; }
        #endif

        private void OnDrawGizmos()
        {
            if (RootUICanvas == null || RootUICanvas.Canvas == null) { return; }

            Matrix4x4 previousMatrix = Gizmos.matrix;
            Gizmos.matrix = RootUICanvas.Canvas.GetCanvasMatrix();
            Gizmos.color  = Color.red;
            Gizmos.DrawSphere(GetSelectorPosition(), 1f);
            Gizmos.color  = Color.white;
            Gizmos.matrix = previousMatrix;
        }

        public virtual Vector3 GetSelectorPosition() => RectTransform == null ? transform.position : RectTransform.position;

        public virtual void OnSelect(BaseEventData eventData)
        {
            _isSelected = true;
            _onSelectUnityEvent.Invoke(eventData);
        }

        public virtual void OnDeselect(BaseEventData eventData) { _isSelected = false; }
    }
}