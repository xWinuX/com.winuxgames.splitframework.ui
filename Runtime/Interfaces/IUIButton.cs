using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.ScriptableObjects.Styles;

namespace WinuXGames.SplitFramework.UI.Interfaces
{
    public interface IUIButton : IUI<SO_UIStyleButton>
    {
        Button  Button { get; }
        IUIText Text   { get; }
    }
}