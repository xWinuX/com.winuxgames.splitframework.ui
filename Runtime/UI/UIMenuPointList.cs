using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using WinuXGames.SplitFramework.Core.Providers;

namespace WinuXGames.SplitFramework.UI.UI
{
    public class UIMenuPointList : MonoBehaviour
    {
        [SerializeField] private SO_EventSystemProvider _eventSystemProvider;

        [SerializeField] private GameObject _menuSelectorPrefab;
        [SerializeField] private Vector3    _selectorOffset = new Vector3(-10f, 0f, 0f);

        [SerializeField] private List<UISelectable> _selectables = new List<UISelectable>();

        [SerializeField] private bool _active;


        private GameObject _selector;
        private GameObject _currentGameObject;

        private void Start()
        {
            if (_selectables.Count > 0 && _active)
            {
                _eventSystemProvider.EventSystem.SetSelectedGameObject(_selectables[0].gameObject);
                _eventSystemProvider.EventSystem.firstSelectedGameObject = _selectables[0].gameObject;
                _currentGameObject                                       = _selectables[0].gameObject;
            }

            _selector                    = Instantiate(_menuSelectorPrefab, transform);
            _selector.transform.position = GetPosition(_selectables[0].gameObject);
        }

        private void Update()
        {
            GameObject newlySelectedGameObject = _eventSystemProvider.EventSystem.currentSelectedGameObject;

            if (newlySelectedGameObject == null) { return; }

            if (newlySelectedGameObject.Equals(_currentGameObject)) { return; }

            MoveSelector(GetPosition(newlySelectedGameObject));
            _currentGameObject = newlySelectedGameObject;
        }

        private void MoveSelector(Vector3 position)
        {
            _selector.transform.DOKill();
            _selector.transform.DOMove(position, 0.125f).SetEase(Ease.OutBack);
        }

        private readonly Vector3[] _corners = new Vector3[4];

        private Vector3 GetPosition(GameObject go)
        {
            RectTransform rectTransform = go.GetComponent<RectTransform>();
            
            if (rectTransform == null) { return go.transform.position; }

            rectTransform.GetWorldCorners(_corners);

            return ((_corners[0] + _corners[1]) / 2) + _selectorOffset;

        }
    }
}