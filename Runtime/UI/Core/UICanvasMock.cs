using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Interfaces;

namespace WinuXGames.SplitFramework.UI.UI
{
    public struct UICanvasMock : ICanvas
    {
        public Canvas       Canvas                 { get; }
        public CanvasScaler CanvasScaler           { get; }
        public RenderMode   RenderMode             => RenderMode.ScreenSpaceOverlay;
        public float        ReferencePixelsPerUnit => 36;
    }
}