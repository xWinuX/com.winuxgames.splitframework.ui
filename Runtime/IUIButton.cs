using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI
{
    public interface IUIButton : IUI<SO_UIStyleButton>
    {
        Button Button { get; }
    }
}