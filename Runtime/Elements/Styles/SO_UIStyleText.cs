using TMPro;
using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Styles.Core;

namespace WinuXGames.SplitFramework.UI.Elements.Styles
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Styles/Text", fileName = "UIStyleText", order = 0)]
    public class SO_UIStyleText : SO_UIStyle<UIText>
    {
        [SerializeField] private TMP_FontAsset _font;
        [SerializeField] private Color         _color = Color.white;
        [SerializeField] private float         _size;

        public TMP_FontAsset Font  => _font;
        public Color         Color => _color;
        public float         Size  => _size;

        public override void Apply(UIText text)
        {
            text.Text.font     = _font;
            text.Text.fontSize = text.RootUICanvas.RenderMode == RenderMode.WorldSpace ? _size / text.RootUICanvas.ReferencePixelsPerUnit : _size;
        }
    }
}