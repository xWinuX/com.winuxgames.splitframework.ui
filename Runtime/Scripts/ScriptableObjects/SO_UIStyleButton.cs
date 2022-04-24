using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WinuXGames.SplitFramework.UI.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Styles/Button", fileName = "UIStyleButton", order = 1)]
    public class SO_UIStyleButton : SO_UIStyle
    {
        [SerializeField] private SO_UIStyleText _textStyle;
        [SerializeField] private Sprite         _inactiveSprite;
        [SerializeField] private Sprite         _activeSprite;

        public void Apply(Button button, TMP_Text text, RenderMode renderMode, float pixelPerUnit)
        {
            button.image.sprite = _inactiveSprite;

            // Apply active sprite
            SpriteState buttonSpriteState = button.spriteState;
            buttonSpriteState.disabledSprite    = _activeSprite;
            buttonSpriteState.highlightedSprite = _activeSprite;
            buttonSpriteState.pressedSprite     = _activeSprite;
            buttonSpriteState.selectedSprite    = _activeSprite;
            button.spriteState                  = buttonSpriteState;

            _textStyle.Apply(text, renderMode, pixelPerUnit);
        }
    }
}