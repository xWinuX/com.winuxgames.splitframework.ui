using System.Collections.Generic;
using WinuXGames.SplitFramework.Core;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Elements.Core
{
    public interface ISelectablesContainer : ITransform
    {
        List<ISelectable> Selectables        { get; }
    }
}