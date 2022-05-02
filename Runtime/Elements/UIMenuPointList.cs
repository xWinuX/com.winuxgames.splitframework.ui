using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Extensions;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public class UIMenuPointList : UIBase
    {
        [SerializeField] private bool                      _active;
        [SerializeField] private List<UISelectable>        _selectables = new List<UISelectable>();
        [SerializeField] private UnityEvent<BaseEventData> _onMenuPointSelected;

        private UISelectorBase _selector;
        private GameObject     _currentGameObject;
        private EventSystem    _eventSystem;

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

        private void OnDrawGizmos()
        {
            Matrix4x4 previousMatrix = Gizmos.matrix;
            Gizmos.matrix = RootUICanvas.Canvas.GetCanvasMatrix();


            Gizmos.matrix = previousMatrix;
        }

        private void OnMenuPointSelected(BaseEventData data) { _onMenuPointSelected.Invoke(data); }
    }
}