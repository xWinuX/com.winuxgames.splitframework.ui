using UnityEngine;
using UnityEngine.EventSystems;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours;
using WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Core;

namespace WinuXGames.SplitFramework.UI.Selectables.Core
{
    public class UISelectableWithBehaviour<TUIElement, TSelectBehaviour> : UISelectable
        where TUIElement : UIBase
        where TSelectBehaviour : SO_UISelectBehaviour<TUIElement>
    {
        [SerializeField] private TSelectBehaviour _selectBehaviourSO;
        [SerializeField] private TUIElement       _uiElement;

        protected TUIElement UIElement => _uiElement;
        
        private ISelectBehaviour<TUIElement> _selectBehaviour;

        protected override void Awake()
        {
            base.Awake();
            _selectBehaviour = _selectBehaviourSO == null ? new SelectBehaviourMock<TUIElement>() : _selectBehaviourSO;
        }

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