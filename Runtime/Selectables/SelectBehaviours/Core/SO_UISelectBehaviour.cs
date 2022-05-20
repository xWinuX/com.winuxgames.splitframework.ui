using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Core;

namespace WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Core
{
    public abstract class SO_UISelectBehaviour<T> : ScriptableObject, ISelectBehaviour<T>
    {
        public abstract void OnSelect(T element);
        public abstract void OnDeselect(T element);
    }
}