using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WinuXGames.SplitFramework.UI.ScriptableObjects
{
    [CreateAssetMenu(menuName = "UI/Styles/Button", fileName = "UIStyleButton", order = 1)]
    public class SO_UIStyleButton : ScriptableObject
    {
        [SerializeField] private SO_UIStyleText _textStyle;
        [SerializeField] private Sprite         _inactiveSprite;
        [SerializeField] private Sprite         _activeSprite;

        public void Apply(Button button, TMP_Text buttonText)
        {
            button.image.sprite = _inactiveSprite;
            
            // Apply active sprite
            SpriteState buttonSpriteState = button.spriteState;
            buttonSpriteState.disabledSprite    = _activeSprite;
            buttonSpriteState.highlightedSprite = _activeSprite;
            buttonSpriteState.pressedSprite     = _activeSprite;
            buttonSpriteState.selectedSprite    = _activeSprite;
            button.spriteState                  = buttonSpriteState;

            _textStyle.Apply(buttonText);
        }
    }
}