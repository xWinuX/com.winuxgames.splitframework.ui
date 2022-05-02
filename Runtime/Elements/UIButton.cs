using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Core;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Elements.Styles;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public class UIButton : UIBaseWithStyle<SO_UIStyleButton>
    {
        [SerializeField] private Button          _button;
        [SerializeField] private UIText          _buttonText;
        [SerializeField] private Navigation.Mode _navigationMode;
        [SerializeField] private bool            _navigationWrapAround = true;

        public Button Button => _button;
        public UIText Text   => _buttonText;

        public void SetText(string text) { _buttonText.SetText(text); }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            if (_button == null || Style == null || _buttonText == null) { return; }

            // Apply navigation
            Navigation buttonNavigation = _button.navigation;
            buttonNavigation.mode       = _navigationMode;
            buttonNavigation.wrapAround = _navigationWrapAround;
            _button.navigation          = buttonNavigation;

            // Apply style
            Style.Apply(this);
        }
    }
}