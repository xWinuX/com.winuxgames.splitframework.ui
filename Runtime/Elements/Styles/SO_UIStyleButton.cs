using UnityEngine;
using UnityEngine.UI;

namespace WinuXGames.SplitFramework.UI.Elements.Styles
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Styles/Button", fileName = "UIStyleButton", order = 1)]
    public class SO_UIStyleButton : SO_UIStyle<UIButton>
    {
        [SerializeField] private SO_UIStyleText _textStyle;
        [SerializeField] private Sprite              _inactiveSprite;
        [SerializeField] private Sprite              _activeSprite;

        public override void Apply(UIButton button)
        {
            button.Button.image.sprite = _inactiveSprite;

            // Apply active sprite
            SpriteState buttonSpriteState = button.Button.spriteState;
            buttonSpriteState.disabledSprite    = _activeSprite;
            buttonSpriteState.highlightedSprite = _activeSprite;
            buttonSpriteState.pressedSprite     = _activeSprite;
            buttonSpriteState.selectedSprite    = _activeSprite;
            button.Button.spriteState           = buttonSpriteState;

            button.Text.SetStyle(_textStyle);
        }
    }
}