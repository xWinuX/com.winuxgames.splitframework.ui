using UnityEngine;

namespace WinuXGames.SplitFramework.UI.Interfaces
{
    public struct UICanvasMock : IUICanvas
    {
        public RenderMode RenderMode             => RenderMode.ScreenSpaceOverlay;
        public float      ReferencePixelsPerUnit => 36;
    }
}