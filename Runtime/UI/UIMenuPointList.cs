using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using WinuXGames.SplitFramework.Core.Providers;

namespace WinuXGames.SplitFramework.UI.UI
{
    public class UIMenuPointList : MonoBehaviour
    {
        [SerializeField] private SO_EventSystemProvider _eventSystemProvider;

        [SerializeField] private GameObject         _menuSelectorPrefab;
        [SerializeField] private List<UISelectable> _selectables = new List<UISelectable>();

        [SerializeField] private bool _active;


        private GameObject _selector;
        private GameObject _currentGameObject;

        private void Start()
        {
            if (_selectables.Count > 0 && _active)
            {
                _eventSystemProvider.EventSystem.SetSelectedGameObject(_selectables[0].gameObject);
                _currentGameObject = _selectables[0].gameObject;
            }

            _selector = Instantiate(_menuSelectorPrefab, transform);

            MoveSelector(GetPosition(_eventSystemProvider.EventSystem.currentSelectedGameObject));
        }

        private void Update()
        {
            GameObject newlySelectedGameObject = _eventSystemProvider.EventSystem.currentSelectedGameObject;

            if (newlySelectedGameObject == null) { return; }

            if (newlySelectedGameObject.Equals(_currentGameObject)) { return; }

            MoveSelector(newlySelectedGameObject.transform.position);
            _currentGameObject = _eventSystemProvider.EventSystem.currentSelectedGameObject;
        }

        private void MoveSelector(Vector3 position)
        {
            _selector.transform.DOKill();
            _selector.transform.DOMove(position, 0.125f).SetEase(Ease.InBack);
        }

        private Vector3 GetPosition(GameObject go)
        {
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            if (rectTransform != null) { return rectTransform.anchorMin; }

            return go.transform.position;
        }
    }
}