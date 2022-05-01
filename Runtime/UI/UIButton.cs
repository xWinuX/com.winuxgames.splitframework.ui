using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.Core;
using WinuXGames.SplitFramework.UI.Interfaces;
using WinuXGames.SplitFramework.UI.ScriptableObjects.Styles;
using WinuXGames.SplitFramework.UI.UI.Core;

namespace WinuXGames.SplitFramework.UI.UI
{
    public class UIButton : UIBase<SO_UIStyleButton>, IUIButton
    {
        [SerializeField] private Button                      _button;
        [SerializeField] private InterfaceReference<IUIText> _buttonText;
        [SerializeField] private Navigation.Mode             _navigationMode;
        [SerializeField] private bool                        _navigationWrapAround = true;

        public Button  Button => _button;
        public IUIText Text   => _buttonText.Target;

        public void SetText(string text) { _buttonText.Target.SetText(text); }

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