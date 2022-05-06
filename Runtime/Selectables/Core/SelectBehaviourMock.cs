using WinuXGames.SplitFramework.UI.Elements.Core;

namespace WinuXGames.SplitFramework.UI.Selectables.Core
{
    public class SelectBehaviourMock<T> : ISelectBehaviour<T> where T : UIBase
    {
        public void OnSelect(T   element) {  }
        public void OnDeselect(T element) {  }
    }
}