namespace WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Core
{
    public interface ISelectBehaviour<in T>
    {
        void OnSelect(T   element);
        void OnDeselect(T element);
    }
}