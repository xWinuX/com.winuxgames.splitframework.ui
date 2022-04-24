using TMPro;
using UnityEngine;

namespace WinuXGames.SplitFramework.UI.ScriptableObjects
{
    [CreateAssetMenu(menuName = "UI/Styles/Text", fileName = "UIStyleText", order = 0)]
    public class SO_UIStyleText : ScriptableObject
    {
        [SerializeField] private TMP_FontAsset _font;
        [SerializeField] private float         _size;

        public void Apply(TMP_Text text)
        {
            text.font     = _font;
            text.fontSize = _size;
        }
    }
}