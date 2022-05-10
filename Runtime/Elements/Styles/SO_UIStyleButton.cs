using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace WinuXGames.SplitFramework.UI.Elements.Styles
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Styles/Button", fileName = "UIStyleButton", order = 1)]
    public class SO_UIStyleButton : SO_UIStyle<UIButton>
    {
        [SerializeField] private SO_UIStyleText _textStyle;
        [FormerlySerializedAs("_inactiveSprite")] [SerializeField]
        private Sprite _sprite;

        public Sprite Sprite => _sprite;

        public override void Apply(UIButton button)
        {
            button.Button.image.sprite = _sprite;

            button.Text.SetStyle(_textStyle);
        }
    }
}