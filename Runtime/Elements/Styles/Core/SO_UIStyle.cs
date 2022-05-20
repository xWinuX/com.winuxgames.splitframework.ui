using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Core;

namespace WinuXGames.SplitFramework.UI.Elements.Styles.Core
{
    public abstract class SO_UIStyle<T> : ScriptableObject where T : UIBase
    {
        public abstract void Apply(T element);
    }

}