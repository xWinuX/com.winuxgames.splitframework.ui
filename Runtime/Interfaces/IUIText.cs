using TMPro;
using WinuXGames.SplitFramework.UI.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI.Interfaces
{
    public interface IUIText : IUI<SO_UIStyleText>
    {
        TMP_Text Text { get; }
    }
}