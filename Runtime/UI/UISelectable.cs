using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WinuXGames.SplitFramework.Core.Providers;

namespace WinuXGames.SplitFramework.UI.UI
{
    public class UISelectable : Selectable
    {
        [SerializeField] private SO_UIDependencyProvider   _uiDependency;
        [SerializeField] private UnityEvent<BaseEventData> _onSelectUnityEvent;
        [SerializeField] private UnityEvent                _onSubmitUnityEvent;

        private bool _isSelected;

        private void Update()
        {
            if (_isSelected && _uiDependency.InputModule.submit.action.WasPerformedThisFrame()) { _onSubmitUnityEvent.Invoke(); }
        }

        public UnityEvent<BaseEventData> OnSelectUnityEvent => _onSelectUnityEvent;

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