using System.Collections.Generic;
using WinuXGames.SplitFramework.Core;
using WinuXGames.SplitFramework.UI.Selectables;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public interface ISelectablesContainer : ITransform
    {
        List<ISelectable> Selectables { get; }
    }
}