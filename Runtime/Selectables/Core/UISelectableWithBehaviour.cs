using UnityEngine;
using UnityEngine.EventSystems;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours;

namespace WinuXGames.SplitFramework.UI.Selectables.Core
{
    public class UISelectableWithBehaviour<TUIElement, TSelectBehaviour> : UISelectable
        where TUIElement : UIBase
        where TSelectBehaviour : SO_UISelectBehaviour<TUIElement>
    {
        [SerializeField] private TSelectBehaviour _selectBehaviour;
        [SerializeField] private TUIElement       _uiElement;

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