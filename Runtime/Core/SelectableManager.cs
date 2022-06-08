using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using WinuXGames.SplitFramework.Utility;
using WinuXGames.SplitFramework.UI.Elements;
using WinuXGames.SplitFramework.UI.Elements.Core;
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
            if (SelectablesContainer != null) { SetSelectableContainer(SelectablesContainer, 0, _defaultSelector); }

            StartCoroutine(CoroutineUtility.WaitForOneFrame(() => _ready = true));
        }

        private void Update()
        {
            if (!_ready || _history.Count == 0) { return; }

            SelectorHistoryEntry historyEntry = _history.Peek();

            GameObject newlySelectedGameObject = _uiDependency.EventSystem.currentSelectedGameObject;

            if (newlySelectedGameObject == null || newlySelectedGameObject.Equals(historyEntry.CurrentlySelected)) { return; }

            historyEntry.CurrentlySelected = newlySelectedGameObject;
            ISelectable uiSelectable = historyEntry.CurrentlySelected.GetComponent<ISelectable>();

            if (historyEntry.HasSelector) { historyEntry.Selector.Move(uiSelectable.GetSelectorPosition()); }
        }

        public void Block()
        {
            _uiDependency.EventSystem.enabled = false;
            Blocked                           = true;
        }

        public void Unblock()
        {
            _uiDependency.EventSystem.enabled = true;
            Blocked                           = false;
        }

        public void SetSelectableContainer(ISelectablesContainer container, int position = 0, UISelectorBase selectorPrefab = null)
        {
            if (container.Selectables.Count == 0) { return; }

            ClearHistory();
            AssignNewContainerAndPrefab(container, position, selectorPrefab);
        }

        public void AddSelectableContainer(ISelectablesContainer container, int position = 0, UISelectorBase selectorPrefab = null)
        {
            if (container.Selectables.Count == 0) { return; }

            AssignNewContainerAndPrefab(container, position, selectorPrefab);
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
            if (selectorHistoryEntry.HasSelector) { selectorHistoryEntry.Selector.Enter(); }

            BlockForOneFrame();
            _uiDependency.EventSystem.SetSelectedGameObject(selectorHistoryEntry.CurrentlySelected);
        }

        private void AssignNewContainerAndPrefab(ISelectablesContainer container, int position, UISelectorBase selectorPrefab)
        {
            if (_history.Count > 0)
            {
                SelectorHistoryEntry selectorHistoryEntry = _history.Peek();
                if (selectorHistoryEntry.HasSelector) { selectorHistoryEntry.Selector.Leave(); }
            }

            BlockForOneFrame();

            GameObject currentlySelected = container.Selectables[position].gameObject;
            _history.Push(new SelectorHistoryEntry(container, CreateAndInitializeSelector(container, position, selectorPrefab), currentlySelected));
            _uiDependency.EventSystem.SetSelectedGameObject(currentlySelected);
        }

        private void BlockForOneFrame()
        {
            if (Blocked) { return; }

            Block();
            StartCoroutine(CoroutineUtility.WaitForOneFrame(Unblock));
        }

        private void ClearHistory()
        {
            foreach (SelectorHistoryEntry selectorHistoryEntry in _history.Where(selectorHistoryEntry => selectorHistoryEntry.Selector != null))
            {
                ClearHistoryEntry(selectorHistoryEntry);
            }

            _history.Clear();
        }

        private static void ClearHistoryEntry(SelectorHistoryEntry selectorHistoryEntry)
        {
            if (selectorHistoryEntry.HasSelector) { selectorHistoryEntry.Selector.Close(); }
        }

        private static UISelectorBase CreateAndInitializeSelector(ISelectablesContainer container, int position = 0, UISelectorBase selectorPrefab = null)
        {
            UISelectorBase selector = selectorPrefab == null ? null : Instantiate(selectorPrefab, container.transform);

            if (selector == null) { return selector; }

            Canvas.ForceUpdateCanvases();
            selector.transform.position = container.Selectables[position].GetSelectorPosition();

            return selector;
        }
    }
}