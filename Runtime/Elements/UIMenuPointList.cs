using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Extensions;
using WinuXGames.SplitFramework.UI.Selectables.Core;
using WinuXGames.SplitFramework.UI.Utility;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public class UIMenuPointList : UIBase, ISelectablesContainer
    {
        [SerializeField] private List<Selectable> _selectables = new List<Selectable>();
        [SerializeField] private NavigationMode   _navigationMode;

        [SerializeField] private UnityEvent<BaseEventData> _onMenuPointSelected;

        public List<ISelectable> Selectables { get; } = new List<ISelectable>();

        private UISelectorBase _selector;
        private GameObject     _currentGameObject;

        protected override void Awake()
        {
            base.Awake();
            UIUtility.ConfigureNavigation(_selectables, _navigationMode);
            //foreach (Selectable selectable in _selectables) { Selectables.Add(selectable.GetComponent<ISelectable>()); }
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

    public class UIInputField : TMP_InputField, ISelectable
    {
        [SerializeField] private UnityEvent<BaseEventData> _onSelectUnityEvent;

        public Vector3                   GetSelectorPosition() => m_RectTransform.GetCenterLeftPosition(_corners);
        public UnityEvent<BaseEventData> OnSelectUnityEvent    => _onSelectUnityEvent;

        private readonly Vector3[] _corners = new Vector3[4];
    }
}