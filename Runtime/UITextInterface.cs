using TMPro;
using UnityEngine;
using WinuXGames.SplitFramework.UI.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI
{
    public class UITextInterface : UIInterface
    {
        [SerializeField] private SO_UIStyleText _style;

        [SerializeField] private TMP_Text _text;

        public TMP_Text Text => _text;

        public void SetText(string text) { _text.text = text; }

        private void OnValidate() { _style.Apply(_text); }
    }
}