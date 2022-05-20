using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Styles.Core;

namespace WinuXGames.SplitFramework.UI.Elements.Core
{
    public abstract class UIBaseWithStyle<TElement, TStyle> : UIBase 
        where TStyle : SO_UIStyle<TElement>
        where TElement : UIBase
    {
        [SerializeField] private TStyle _style;

        public TStyle Style { get => _style; private set => _style = value; }

        public void SetStyle(TStyle style)
        {
            Style = style;
            ApplyStyle();
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();
            Style.Apply(this as TElement);
        }
    }
}