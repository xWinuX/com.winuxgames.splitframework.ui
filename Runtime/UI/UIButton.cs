using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Interfaces;
using WinuXGames.SplitFramework.UI.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI.UI
{
    public class UIButton : UIBase<SO_UIStyleButton>, IUIButton
    {
        [SerializeField] private Button          _button;
        [SerializeField] private UIText          _buttonText;
        [SerializeField] private Navigation.Mode _navigationMode;
        [SerializeField] private bool            _navigationWrapAround = true;

        public Button Button => _button;

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
            Style.Apply(this, _buttonText);
        }
    }
}