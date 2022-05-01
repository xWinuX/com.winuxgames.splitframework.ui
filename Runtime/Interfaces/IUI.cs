using UnityEngine;
using WinuXGames.SplitFramework.UI.ScriptableObjects.Styles;

namespace WinuXGames.SplitFramework.UI.Interfaces
{
    public interface IUI
    {
        RectTransform RectTransform { get; }
        ICanvas       RootUICanvas  { get; }
        void          AssignRootCanvas(ICanvas rootCanvas);
    }
    
    public interface IUI<TStyle> : IUI where TStyle : SO_UIStyle
    {

        TStyle        Style { get; }
        void          SetStyle(TStyle style);
    }
}