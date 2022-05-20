using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Styles.Core;

namespace WinuXGames.SplitFramework.UI.Elements.Styles
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Styles/Button", fileName = "UIStyleButton", order = 1)]
    public class SO_UIStyleButton : SO_UIStyleImage<UIButton>
    {
        [SerializeField] private SO_UIStyleText _textStyle;
        

        public override void Apply(UIButton button)
        {
            base.Apply(button);

            button.Text.SetStyle(_textStyle);
        }
    }
}