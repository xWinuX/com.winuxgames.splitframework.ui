using TMPro;
using UnityEngine;
using WinuXGames.SplitFramework.UI.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI.Interfaces
{
    public class UITextInterface : UIInterface<SO_UIStyleText>, IUIText
    {
        [SerializeField] private TMP_Text _text;

        public TMP_Text Text => _text;

        public void SetText(string text) { _text.text = text; }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();
            
            Style.Apply(this);
        }
    }
}