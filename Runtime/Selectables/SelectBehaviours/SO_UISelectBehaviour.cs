using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours
{
    public abstract class SO_UISelectBehaviour<T> : ScriptableObject, ISelectBehaviour<T> where T : UIBase
    {
        public abstract void OnSelect(T element);
        public abstract void OnDeselect(T element);
    }
}