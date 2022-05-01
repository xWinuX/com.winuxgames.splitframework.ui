using TMPro;
using WinuXGames.SplitFramework.UI.ScriptableObjects;
using WinuXGames.SplitFramework.UI.ScriptableObjects.Styles;

namespace WinuXGames.SplitFramework.UI.Interfaces
{
    public interface IUIText : IUI<SO_UIStyleText>
    {
        TMP_Text Text { get; }

        void SetText(string text); 
    }
}