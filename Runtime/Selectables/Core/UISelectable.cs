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
    [DefaultExecutionOrder(-1)]
    public abstract class UISelectable : MonoBehaviour, ISelectable, IUIBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField] private SO_UIDependencyProvider   _uiDependency;
        [SerializeField] private UnityEvent<BaseEventData> _onSelectUnityEvent;
        [SerializeField] private UnityEvent                _onSubmitUnityEvent;

        public UnityEvent                OnSubmitUnityEvent => _onSubmitUnityEvent;
        public UnityEvent<BaseEventData> OnSelectUnityEvent => _onSelectUnityEvent;

        public RectTransform RectTransform { get; protected set; }
        public ICanvas       RootUICanvas  { get; private set; } = new UICanvasMock();
        public Selectable    Selectable    { get; private set; }

        private bool _isSelected;
        private bool _showSelectable;

        protected virtual void Awake()
        {
            GetSelectable();
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

        private void OnValidate()
        {
            GetSelectable();
            RectTransform = GetComponent<RectTransform>();
            RootUICanvas  = UIUtility.GetRootCanvasOrDefault(gameObject);
        }

        private void GetSelectable()
        {
            Selectable = GetComponent<Selectable>();
            SetSelectableHideFlags();
        }

        private void Reset() { SetSelectableHideFlags(); }

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

        [ContextMenu("Show Selectable")]
        private void ShowSelectable()
        {
            _showSelectable = true;
            SetSelectableHideFlags();
        }

        [ContextMenu("Hide Selectable")]
        private void HideSelectable()
        {
            _showSelectable = false;
            SetSelectableHideFlags();
        }

        private void SetSelectableHideFlags()
        {
            if (Selectable == null) { return; }

            Selectable.hideFlags = _showSelectable ? HideFlags.None : HideFlags.NotEditable | HideFlags.HideInInspector;
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