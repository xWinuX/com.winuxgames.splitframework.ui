using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Scripts.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI.Scripts.Interfaces
{
    public class UIButtonInterface : UIInterface<SO_UIStyleButton>
    {
        [SerializeField] private Button          _button;
        [SerializeField] private UITextInterface _buttonTextInterface;
        [SerializeField] private Navigation.Mode _navigationMode;
        [SerializeField] private bool            _navigationWrapAround = true;

        public Button Button => _button;

        public void SetText(string text) { _buttonTextInterface.SetText(text); }

        private void OnValidate() { ApplyStyle(); }

        protected override void ApplyStyle()
        {
            // Apply navigation
            Navigation buttonNavigation = _button.navigation;
            buttonNavigation.mode       = _navigationMode;
            buttonNavigation.wrapAround = _navigationWrapAround;
            _button.navigation          = buttonNavigation;

            // Apply style
            Style.Apply(_button, _buttonTextInterface.Text, RootCanvasInterface.Style.RenderMode, RootCanvasInterface.Style.ReferencePixelPerUnit);
        }
    }
}