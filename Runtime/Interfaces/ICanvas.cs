using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.ScriptableObjects.Styles;

namespace WinuXGames.SplitFramework.UI.Interfaces
{
    public interface ICanvas
    {
        Canvas       Canvas                 { get; }
        CanvasScaler CanvasScaler           { get; }
        RenderMode   RenderMode             { get; }
        float        ReferencePixelsPerUnit { get; } 
    }
}