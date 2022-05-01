using UnityEngine;
using WinuXGames.SplitFramework.UI.Interfaces;

namespace WinuXGames.SplitFramework.UI.ScriptableObjects.SelectionBehaviours
{
    public abstract class SO_UISelectionBehaviour<T> : ScriptableObject where T : IUI
    {
        public abstract void OnSelect(T element);
        public abstract void OnDeselect(T element);
    }
}