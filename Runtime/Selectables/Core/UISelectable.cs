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
    public abstract class UISelectable : Selectable, ISelectable, IUIBehaviour
    {
        [SerializeField] private SO_UIDependencyProvider   _uiDependency;
        [SerializeField] private UnityEvent<BaseEventData> _onSelectUnityEvent;
        [SerializeField] private UnityEvent                _onSubmitUnityEvent;

        public UnityEvent<BaseEventData> OnSelectUnityEvent => _onSelectUnityEvent;

        public RectTransform RectTransform { get; protected set; }
        public ICanvas       RootUICanvas  { get; private set; } = new UICanvasMock();

        private bool _isSelected;

        protected override void Awake()
        {
            base.Awake();
            RectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (_isSelected && _uiDependency.InputModule.submit.action.WasPerformedThisFrame()) { _onSubmitUnityEvent.Invoke(); }
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            RectTransform = GetComponent<RectTransform>();

            ICanvas canvas = UIUtility.TryGetRootCanvas(gameObject);
            if (canvas != null) { RootUICanvas = canvas; }

            RootUICanvas ??= new UICanvasMock();
        }

        private void OnDrawGizmos()
        {
            Matrix4x4 previousMatrix = Gizmos.matrix;
            Gizmos.matrix = RootUICanvas.Canvas.GetCanvasMatrix();
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(GetSelectorPosition(), 1f);
            Gizmos.color  = Color.white;
            Gizmos.matrix = previousMatrix;
        }

        public virtual Vector3 GetSelectorPosition() => RectTransform == null ? transform.position : RectTransform.position;

        public override void OnSelect(BaseEventData eventData)
        {
            _isSelected = true;
            _onSelectUnityEvent.Invoke(eventData);
            base.OnSelect(eventData);
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            _isSelected = false;
            base.OnDeselect(eventData);
        }
    }
}