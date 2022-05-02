using System.Collections.Generic;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public interface ISelectableContainer
    {
        List<UISelectable> Selectables { get; }
    }
}