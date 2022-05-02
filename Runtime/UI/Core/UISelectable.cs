using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WinuXGames.SplitFramework.Core;
using WinuXGames.SplitFramework.Core.Providers;
using WinuXGames.SplitFramework.UI.Interfaces;
using WinuXGames.SplitFramework.UI.ScriptableObjects.SelectBehaviour;

namespace WinuXGames.SplitFramework.UI.UI.Core
{
    public abstract class UISelectable : Selectable
    {
        [SerializeField] private SO_UIDependencyProvider   _uiDependency;
        [SerializeField] private UnityEvent<BaseEventData> _onSelectUnityEvent;
        [SerializeField] private UnityEvent                _onSubmitUnityEvent;

        public UnityEvent<BaseEventData> OnSelectUnityEvent => _onSelectUnityEvent;

        private bool _isSelected;

        private void Update()
        {
            if (_isSelected && _uiDependency.InputModule.submit.action.WasPerformedThisFrame()) { _onSubmitUnityEvent.Invoke(); }
        }

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

    public class UISelectable<TUIElement, TSelectBehaviour> : UISelectable
        where TUIElement : UIBase
        where TSelectBehaviour : SO_UISelectBehaviour<TUIElement>
    {
        [SerializeField] private TSelectBehaviour _selectBehaviour;
        [SerializeField] private TUIElement      _uiElement;

        public override void OnSelect(BaseEventData eventData)
        {
            _selectBehaviour.OnSelect(_uiElement);
            base.OnSelect(eventData);
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            _selectBehaviour.OnDeselect(_uiElement);
            base.OnDeselect(eventData);
        }
    }
}