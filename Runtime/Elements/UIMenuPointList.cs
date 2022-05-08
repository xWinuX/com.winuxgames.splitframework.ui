using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Selectables;
using WinuXGames.SplitFramework.UI.Selectables.Core;
using WinuXGames.SplitFramework.UI.Utility;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public class UIMenuPointList : UIBase, ISelectablesContainer
    {
        [SerializeField] private List<UISelectable> _selectables = new List<UISelectable>();
        [SerializeField] private NavigationMode     _navigationMode;

        [SerializeField] private UnityEvent<BaseEventData> _onMenuPointSelected;

        public List<ISelectable> Selectables { get; private set; }

        private UISelectorBase   _selector;
        private  GameObject       _currentGameObject;

        protected override void Awake()
        {
            base.Awake();
            UIUtility.ConfigureNavigation(_selectables, _navigationMode);
            Selectables = _selectables.ConvertAll(input => input as ISelectable);
        }

        private void Start()
        {
            foreach (UISelectable uiSelectable in _selectables) { uiSelectable.OnSelectUnityEvent.AddListener(OnMenuPointSelected); }
        }


        private void OnMenuPointSelected(BaseEventData data) { _onMenuPointSelected.Invoke(data); }
    }
}