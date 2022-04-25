using TMPro;
using UnityEngine;

namespace WinuXGames.SplitFramework.UI.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Styles/Text", fileName = "UIStyleText", order = 0)]
    public class SO_UIStyleText : SO_UIStyle
    {
        [SerializeField] private TMP_FontAsset _font;
        [SerializeField] private float         _size;

        public void Apply(IUIText text)
        {
            text.Text.font     = _font;
            text.Text.fontSize = text.RootUICanvas.RenderMode == RenderMode.WorldSpace ? _size / text.RootUICanvas.ReferencePixelsPerUnit : _size;
        }
    }
}