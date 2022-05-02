using UnityEngine;
using UnityEngine.UI;

namespace WinuXGames.SplitFramework.UI.Core
{
    public struct UICanvasMock : ICanvas
    {
        public Canvas       Canvas                 { get; }
        public CanvasScaler CanvasScaler           { get; }
        public RenderMode   RenderMode             => RenderMode.ScreenSpaceOverlay;
        public float        ReferencePixelsPerUnit => 36;
    }
}