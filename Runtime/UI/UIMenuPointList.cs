using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using WinuXGames.SplitFramework.UI.Extensions;
using WinuXGames.SplitFramework.UI.UI.Core;
using WinuXGames.SplitFramework.UI.UI.Selectables;

namespace WinuXGames.SplitFramework.UI.UI
{
    public class UIMenuPointList : UIBase
    {
        [Header("Selector")]
        [SerializeField] private UISelectorBase _menuSelectorPrefab;
        [SerializeField] private Vector3 _selectorOffset = new Vector3(-10f, 0f, 0f);

        [Header("Selection")]
        [SerializeField] private List<UISelectable> _selectables = new List<UISelectable>();
        [SerializeField] private UnityEvent<BaseEventData> _onMenuPointSelected;

        [Header("State")]
        [SerializeField] private bool _active;

        private          UISelectorBase _selector;
        private          GameObject     _currentGameObject;
        private          EventSystem    _eventSystem;
        private readonly Vector3[]      _corners = new Vector3[4];


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

            _selector = InstantiateWithRootCanvas(_menuSelectorPrefab, transform);
            StartCoroutine(SetInitialSelectorPositionCoroutine());
        }

        private void Update()
        {
            GameObject newlySelectedGameObject = _eventSystem.currentSelectedGameObject;

            if (newlySelectedGameObject == null) { return; }

            if (newlySelectedGameObject.Equals(_currentGameObject)) { return; }

            _selector.Move(GetPosition(newlySelectedGameObject));
            _currentGameObject = newlySelectedGameObject;
        }

        private void OnDrawGizmos()
        {
            Matrix4x4 previousMatrix = Gizmos.matrix;
            Gizmos.matrix = RootUICanvas.Canvas.GetCanvasMatrix();
            foreach (UISelectable uiSelectable in _selectables) { Gizmos.DrawSphere(GetPosition(uiSelectable.gameObject), 1f); }

            Gizmos.matrix = previousMatrix;
        }

        private void OnMenuPointSelected(BaseEventData data) { _onMenuPointSelected.Invoke(data); }

        private Vector3 GetPosition(GameObject go)
        {
            RectTransform rectTransform = (RectTransform)go.transform;

            if (rectTransform == null) { return go.transform.position; }

            rectTransform.GetWorldCorners(_corners);

            return ((_corners[0] + _corners[1]) / 2) + _selectorOffset;
        }

        private IEnumerator SetInitialSelectorPositionCoroutine()
        {
            yield return null;
            _selector.transform.position = GetPosition(_selectables[0].gameObject);
        }
    }
}