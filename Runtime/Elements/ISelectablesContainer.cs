using System.Collections.Generic;
using UnityEngine.Events;
using WinuXGames.SplitFramework.Core;
using WinuXGames.SplitFramework.UI.Selectables;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public interface ISelectablesContainer : ITransform
    {
        List<ISelectable> Selectables        { get; }
    }
}