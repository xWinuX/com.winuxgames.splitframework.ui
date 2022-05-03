using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Selectables.Core;
using WinuXGames.SplitFramework.UI.Utility;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public class UIMenuPointList : UIBase, ISelectablesContainer
    {
        [SerializeField] private bool               _active;
        [SerializeField] private List<UISelectable> _selectables = new List<UISelectable>();
        [SerializeField] private NavigationMode     _navigationMode;

        [SerializeField] private UnityEvent<BaseEventData> _onMenuPointSelected;

        public List<UISelectable> Selectables => _selectables;

        private UISelectorBase _selector;
        private GameObject     _currentGameObject;
        private EventSystem    _eventSystem;

        protected override void Awake()
        {
            base.Awake();
            UIUtility.ConfigureNavigation(_selectables, _navigationMode);
        }

        private void Start()
        {
            _eventSystem = EventSystem.current;

            if (_selectables.Count > 0 && _active)
            {
                _eventSystem.SetSelectedGameObject(_selectables[0].gameObject);
                _eventSystem.firstSelectedGameObject = _selectables[0].gameObject;
                _currentGameObject                   = _selectables[0].gameObject;
            }

            foreach (UISelectable uiSelectable in _selectables) { uiSelectable.OnSelectUnityEvent.AddListener(OnMenuPointSelected); }
        }

        private void Update()
        {
            GameObject newlySelectedGameObject = _eventSystem.currentSelectedGameObject;

            if (newlySelectedGameObject == null) { return; }

            if (newlySelectedGameObject.Equals(_currentGameObject)) { return; }

            _currentGameObject = newlySelectedGameObject;
        }

        private void OnMenuPointSelected(BaseEventData data) { _onMenuPointSelected.Invoke(data); }
    }
}