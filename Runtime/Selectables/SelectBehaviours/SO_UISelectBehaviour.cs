using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Core;

namespace WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours
{
    public interface ISelectBehaviour<in T> where T : UIBase
    {
        void OnSelect(T   element);
        void OnDeselect(T element);
    }
    
    public abstract class SO_UISelectBehaviour<T> : ScriptableObject, ISelectBehaviour<T> where T : UIBase
    {
        public abstract void OnSelect(T element);
        public abstract void OnDeselect(T element);
    }
}