using UnityEngine;
using UnityEngine.UI;

namespace WinuXGames.SplitFramework.UI.Interfaces
{
    public interface IUICanvas
    {
        Canvas       Canvas                 { get; }
        CanvasScaler CanvasScaler           { get; }
        RenderMode   RenderMode             { get; }
        float        ReferencePixelsPerUnit { get; }
    }
}