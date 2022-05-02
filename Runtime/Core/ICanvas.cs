using UnityEngine;
using UnityEngine.UI;

namespace WinuXGames.SplitFramework.UI.Core
{
    public interface ICanvas
    {
        Canvas       Canvas                 { get; }
        CanvasScaler CanvasScaler           { get; }
        RenderMode   RenderMode             { get; }
        float        ReferencePixelsPerUnit { get; } 
    }
}