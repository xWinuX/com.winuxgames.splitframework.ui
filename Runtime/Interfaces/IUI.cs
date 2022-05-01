using UnityEngine;
using WinuXGames.SplitFramework.UI.ScriptableObjects.Styles;

namespace WinuXGames.SplitFramework.UI.Interfaces
{
    public interface IUI
    {
        RectTransform RectTransform { get; }
        IUICanvas     RootUICanvas  { get; }
        void AssignRootCanvas(IUICanvas rootCanvas);
    }

    public interface IUI<TStyle> : IUI where TStyle : SO_UIStyle
    {
        TStyle Style { get; }
        void   SetStyle(TStyle style);
    }
}