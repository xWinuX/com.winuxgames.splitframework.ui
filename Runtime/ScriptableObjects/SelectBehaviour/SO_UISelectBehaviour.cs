using UnityEngine;
using WinuXGames.SplitFramework.UI.Interfaces;

namespace WinuXGames.SplitFramework.UI.ScriptableObjects.SelectBehaviour
{
    public abstract class SO_UISelectBehaviour<T> : ScriptableObject where T : IUI
    {
        public abstract void OnSelect(T element);
        public abstract void OnDeselect(T element);
    }
}