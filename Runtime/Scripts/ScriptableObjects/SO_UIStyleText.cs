using TMPro;
using UnityEngine;

namespace WinuXGames.SplitFramework.UI.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Styles/Text", fileName = "UIStyleText", order = 0)]
    public class SO_UIStyleText : SO_UIStyle
    {
        [SerializeField] private TMP_FontAsset _font;
        [SerializeField] private float         _size;

        public void Apply(TMP_Text text, RenderMode renderMode, float pixelsPerUnit)
        {
            text.font     = _font;
            text.fontSize = renderMode == RenderMode.WorldSpace ? _size/pixelsPerUnit : _size;
        }
    }
}