using TMPro;
using UnityEngine;
using WinuXGames.SplitFramework.UI.Interfaces;
using WinuXGames.SplitFramework.UI.ScriptableObjects.Styles;
using WinuXGames.SplitFramework.UI.UI.Core;

namespace WinuXGames.SplitFramework.UI.UI.Elements
{
    public class UIText : UIBase<SO_UIStyleText>
    {
        [SerializeField] private TMP_Text _text;

        public TMP_Text Text      => _text;
        
        public void SetText(string text) { _text.text = text; }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();
            
            Style.Apply(this);
        }
    }
}