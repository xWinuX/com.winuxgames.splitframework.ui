using System.Collections.Generic;
using WinuXGames.SplitFramework.Core;
using WinuXGames.SplitFramework.UI.Selectables;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public interface ISelectablesContainer : ITransform
    {
        List<ISelectable> Selectables { get; }
    }
}