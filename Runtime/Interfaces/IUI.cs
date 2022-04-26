using UnityEngine;
using WinuXGames.SplitFramework.UI.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI.Interfaces
{
    public interface IUI
    {
        RectTransform RectTransform { get; }
        IUICanvas     RootUICanvas  { get; }
    }

    public interface IUI<in TStyle> : IUI where TStyle : SO_UIStyle
    {
        void SetStyle(TStyle style);
    }
}