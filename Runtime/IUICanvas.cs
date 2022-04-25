using UnityEngine;

namespace WinuXGames.SplitFramework.UI
{
    public interface IUICanvas
    {
        RenderMode RenderMode             { get; }
        float      ReferencePixelsPerUnit { get; }
    }
}