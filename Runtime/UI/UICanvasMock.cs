using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Interfaces;

namespace WinuXGames.SplitFramework.UI.UI
{
    public struct UICanvasMock : IUICanvas
    {
        public Canvas       Canvas                 { get; }
        public CanvasScaler CanvasScaler           { get; }
        public RenderMode   RenderMode             => RenderMode.ScreenSpaceOverlay;
        public float        ReferencePixelsPerUnit => 36;
    }
}