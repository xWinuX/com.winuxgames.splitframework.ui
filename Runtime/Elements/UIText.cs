using TMPro;
using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Elements.Styles;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public class UIText : UIBaseWithStyle<UIText, SO_UIStyleText>
    {
        [SerializeField] private TMP_Text _text;

        public TMP_Text Text      => _text;
        
        public void SetText(string text) { _text.text = text; }
    }
}