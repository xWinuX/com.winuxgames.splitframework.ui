using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Selectables.Core;
using WinuXGames.SplitFramework.UI.Utility;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public class UIMenuPointList : UIBase, ISelectablesContainer
    {
        [FormerlySerializedAs("_selectables")] [SerializeField]
        private List<Selectable> _unitySelectables = new List<Selectable>();
        [SerializeField] private NavigationMode            _navigationMode;
        [SerializeField] private UnityEvent<BaseEventData> _onMenuPointSelected;

        public List<ISelectable> Selectables { get; } = new List<ISelectable>();

        private readonly List<Selectable>  _filteredUnitySelectables = new List<Selectable>();
        private readonly List<ISelectable> _unfilteredSelectables    = new List<ISelectable>();

        private readonly List<Selectable> _deleteList = new List<Selectable>();

        private UISelectorBase _selector;
        private GameObject     _currentGameObject;

        protected override void Awake()
        {
            base.Awake();
            Validate();
            UpdateStructure();
        }

        private void Start()
        {
            foreach (ISelectable selectable in Selectables) { selectable.OnSelectUnityEvent.AddListener(OnMenuPointSelected); }
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            Validate();
        }

        public void UpdateStructure()
        {
            FilterSelectables();
            UpdateNavigation();
        }

        private void UpdateNavigation() { UIUtility.ConfigureNavigation(_filteredUnitySelectables, _navigationMode); }
        
        private void Validate()
        {
            _deleteList.Clear();
            _unfilteredSelectables.Clear();
            foreach (Selectable unitySelectable in _unitySelectables)
            {
                ISelectable selectableInterface = unitySelectable.GetComponent<ISelectable>();
                if (selectableInterface == null) { _deleteList.Add(unitySelectable); }
                else { _unfilteredSelectables.Add(selectableInterface); }
            }

            foreach (Selectable selectable in _deleteList)
            {
                Debug.LogError(selectable + " must implement ISelectable");
                _unitySelectables.Remove(selectable);
            }
        }

        private void FilterSelectables()
        {
            Selectables.Clear();
            foreach (ISelectable selectable in _unfilteredSelectables)
            {
                if (!selectable.gameObject.activeSelf) { continue; }

                Selectables.Add(selectable);
                _filteredUnitySelectables.Add(selectable.Selectable);
            }
        }

        private void OnMenuPointSelected(BaseEventData data) { _onMenuPointSelected.Invoke(data); }
    }
}