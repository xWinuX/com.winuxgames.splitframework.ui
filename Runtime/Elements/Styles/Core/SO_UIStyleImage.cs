using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Core;

namespace WinuXGames.SplitFramework.UI.Elements.Styles.Core
{
    public abstract class SO_UIStyleImage<TElement> : SO_UIStyle<TElement> where TElement : UIBase, IImage
    {
        [SerializeField] private Sprite _sprite;

        public Sprite Sprite => _sprite;

        public override void Apply(TElement element) { element.Image.sprite = Sprite; }
    }
}