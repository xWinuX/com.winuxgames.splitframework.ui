using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Elements.Styles;
using WinuXGames.SplitFramework.UI.Selectables;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public class UIButton : UIBaseWithStyle<SO_UIStyleButton>
    {
        [SerializeField] private UISelectableButton _button;
        [SerializeField] private UIText             _buttonText;

        public UISelectableButton Button => _button;
        public UIText             Text   => _buttonText;

        public void SetText(string text) { _buttonText.SetText(text); }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            if (_button == null || Style == null || _buttonText == null) { return; }

            // Apply style
            Style.Apply(this);
        }
    }
}