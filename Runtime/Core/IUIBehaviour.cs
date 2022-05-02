using UnityEngine;

namespace WinuXGames.SplitFramework.UI.Core
{
    public interface IUIBehaviour
    {
        RectTransform RectTransform { get; }
        ICanvas       RootUICanvas  { get; }
    }
}