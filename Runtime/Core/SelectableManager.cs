using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using WinuXGames.SplitFramework.Utility;
using WinuXGames.SplitFramework.UI.Elements;
using WinuXGames.SplitFramework.UI.Providers;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Core
{
    public class SelectableManager : SelectableContainerValidator
    {
        [SerializeField] private SO_UIDependencyProvider _uiDependency;
        [SerializeField] private UISelectorBase          _defaultSelector;

        public bool Blocked { get; private set; }

        private readonly Stack<SelectorHistoryEntry> _history = new Stack<SelectorHistoryEntry>();
        private          bool                        _ready;

        private void Awake()
        {
            if (SelectablesContainer != null) { SetSelectableContainer(SelectablesContainer, _defaultSelector); }

            StartCoroutine(CoroutineUtility.WaitForOneFrame(() => _ready = true));
        }

        private void Update()
        {
            if (!_ready || _history.Count == 0) { return; }

            SelectorHistoryEntry historyEntry = _history.Peek();

            GameObject newlySelectedGameObject = _uiDependency.EventSystem.currentSelectedGameObject;

            if (newlySelectedGameObject == null || newlySelectedGameObject.Equals(historyEntry.CurrentlySelected)) { return; }

            historyEntry.CurrentlySelected = newlySelectedGameObject;
            UISelectable uiSelectable = historyEntry.CurrentlySelected.GetComponent<UISelectable>();
            
            historyEntry.Selector.Move(uiSelectable.GetSelectorPosition());
        }

        public void SetSelectableContainer(ISelectablesContainer container, UISelectorBase selectorPrefab = null)
        {
            if (container.Selectables.Count == 0) { return; }

            ClearHistory();
            AssignNewContainerAndPrefab(container, selectorPrefab);
        }

        public void AddSelectableContainer(ISelectablesContainer container, UISelectorBase selectorPrefab = null)
        {
            if (container.Selectables.Count == 0) { return; }

            AssignNewContainerAndPrefab(container, selectorPrefab);
        }

        public void GoBack()
        {
            ClearHistoryEntry(_history.Pop());

            if (_history.Count == 0)
            {
                _uiDependency.EventSystem.SetSelectedGameObject(null);
                return;
            }
            
            SelectorHistoryEntry selectorHistoryEntry = _history.Peek();
            selectorHistoryEntry.Selector.Enter();
            BlockForOneFrame();
            _uiDependency.EventSystem.SetSelectedGameObject(selectorHistoryEntry.CurrentlySelected);
        }

        private void AssignNewContainerAndPrefab(ISelectablesContainer container, UISelectorBase selectorPrefab)
        {
            if (_history.Count > 0)
            {
                SelectorHistoryEntry selectorHistoryEntry = _history.Peek();
                selectorHistoryEntry.Selector.Leave();
            }

            BlockForOneFrame();

            GameObject currentlySelected = container.Selectables[0].gameObject;
            _history.Push(new SelectorHistoryEntry(container, CreateAndInitializeSelector(container, selectorPrefab), currentlySelected));
            _uiDependency.EventSystem.SetSelectedGameObject(currentlySelected);
        }

        private void BlockForOneFrame()
        {
            Blocked = true;
            StartCoroutine(CoroutineUtility.WaitForOneFrame(() => { Blocked = false; }));
        }


        private void ClearHistory()
        {
            foreach (SelectorHistoryEntry selectorHistoryEntry in _history.Where(selectorHistoryEntry => selectorHistoryEntry.Selector != null))
            {
                ClearHistoryEntry(selectorHistoryEntry);
            }

            _history.Clear();
        }

        private static void ClearHistoryEntry(SelectorHistoryEntry selectorHistoryEntry) { selectorHistoryEntry.Selector.Close(); }

        private static UISelectorBase CreateAndInitializeSelector(ISelectablesContainer container, UISelectorBase selectorPrefab = null)
        {
            UISelectorBase selector = selectorPrefab == null ? null : Instantiate(selectorPrefab, container.transform);
            
            if (selector == null) { return selector; }
            
            Canvas.ForceUpdateCanvases();
            selector.transform.position = container.Selectables[0].GetSelectorPosition();

            return selector;
        }
    }
}