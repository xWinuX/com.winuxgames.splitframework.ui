using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Selectables.Core;
using WinuXGames.SplitFramework.UI.Utility;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public class UIMenuPointList : UIBase, ISelectablesContainer
    {
        [SerializeField] private List<Selectable>          _selectables = new List<Selectable>();
        [SerializeField] private NavigationMode            _navigationMode;
        [SerializeField] private UnityEvent<BaseEventData> _onMenuPointSelected;

        public List<ISelectable> Selectables { get; } = new List<ISelectable>();

        private UISelectorBase _selector;
        private GameObject     _currentGameObject;

        protected override void Awake()
        {
            base.Awake();
            UIUtility.ConfigureNavigation(_selectables, _navigationMode);
        }

        private void Start()
        {
            foreach (ISelectable selectable in Selectables) { selectable.OnSelectUnityEvent.AddListener(OnMenuPointSelected); }
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            ValidateSelectables();
        }

        public void UpdateNavigation()
        {
            UIUtility.ConfigureNavigation(_selectables, _navigationMode);
        }

        private void ValidateSelectables()
        {
            Selectables.Clear();
            List<Selectable> deleteList = new List<Selectable>();
            foreach (Selectable selectable in _selectables)
            {
                ISelectable selectableInterface = selectable.GetComponent<ISelectable>();
                if (selectableInterface == null) { deleteList.Add(selectable); }
                else { Selectables.Add(selectableInterface); }
            }

            foreach (Selectable selectable in deleteList)
            {
                Debug.LogError(selectable + " must implement ISelectable");
                _selectables.Remove(selectable);
            }
        }

        private void OnMenuPointSelected(BaseEventData data) { _onMenuPointSelected.Invoke(data); }
    }
}