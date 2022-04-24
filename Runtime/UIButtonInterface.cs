using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI
{
    public class UIButtonInterface : UIInterface
    {
        [SerializeField] private SO_UIStyleButton _style;

        [SerializeField] private Button          _button;
        [SerializeField] private TMP_Text        _buttonText;
        [SerializeField] private Navigation.Mode _navigationMode;
        [SerializeField] private bool            _navigationWrapAround = true;

        public Button   Button => _button;
        public TMP_Text Text   => _buttonText;

        public void SetText(string text) { _buttonText.text = text; }

        private void OnValidate()
        {
            // Apply navigation
            Navigation buttonNavigation = _button.navigation;
            buttonNavigation.mode       = _navigationMode;
            buttonNavigation.wrapAround = _navigationWrapAround;
            _button.navigation          = buttonNavigation;

            // Apply style
            _style.Apply(_button, _buttonText);
        }
    }
}