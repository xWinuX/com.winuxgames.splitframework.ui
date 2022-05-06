using WinuXGames.SplitFramework.UI.Elements.Core;

namespace WinuXGames.SplitFramework.UI.Selectables.Core
{
    public interface ISelectBehaviour<in T> where T : UIBase
    {
        void OnSelect(T   element);
        void OnDeselect(T element);
    }
}