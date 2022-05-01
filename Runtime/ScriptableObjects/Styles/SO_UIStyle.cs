using UnityEngine;

namespace WinuXGames.SplitFramework.UI.ScriptableObjects.Styles
{
    public abstract class SO_UIStyle : ScriptableObject { }

    public abstract class SO_UIStyle<T> : SO_UIStyle
    {
        public abstract void Apply(T element);
    }
}