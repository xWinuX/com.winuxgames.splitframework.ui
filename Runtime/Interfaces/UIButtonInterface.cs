using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI.Interfaces
{
    public class UIButtonInterface : UIInterface<SO_UIStyleButton>, IUIButton
    {
        [SerializeField] private Button          _button;
        [SerializeField] private UITextInterface _buttonTextInterface;
        [SerializeField] private Navigation.Mode _navigationMode;
        [SerializeField] private bool            _navigationWrapAround = true;

        public Button Button => _button;

        public void SetText(string text) { _buttonTextInterface.SetText(text); }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();
            
            if (_button == null || Style == null || _buttonTextInterface == null) { return; }

            // Apply navigation
            Navigation buttonNavigation = _button.navigation;
            buttonNavigation.mode       = _navigationMode;
            buttonNavigation.wrapAround = _navigationWrapAround;
            _button.navigation          = buttonNavigation;

            // Apply style
            Style.Apply(this, _buttonTextInterface);
        }
    }
}