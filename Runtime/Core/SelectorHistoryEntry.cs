using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Core
{
    public class SelectorHistoryEntry
    {
        public UISelectorBase        Selector          { get; }
        public ISelectablesContainer Container         { get; }
        public GameObject            CurrentlySelected { get; set; }

        public bool HasSelector { get; }

        public SelectorHistoryEntry(ISelectablesContainer container, UISelectorBase selector, GameObject currentlySelected)
        {
            Selector          = selector;
            Container         = container;
            CurrentlySelected = currentlySelected;
            HasSelector       = Selector != null;
        }
    }
}