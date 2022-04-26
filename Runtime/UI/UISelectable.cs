using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WinuXGames.SplitFramework.UI.UI
{
    public class UISelectable : Selectable
    {
        [SerializeField] private UnityEvent<BaseEventData> _onSelected;

        public override void OnSelect(BaseEventData eventData)
        {
            _onSelected.Invoke(eventData);
            base.OnSelect(eventData);
        }
    }
}