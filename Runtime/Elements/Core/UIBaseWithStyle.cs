using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Styles;

namespace WinuXGames.SplitFramework.UI.Elements.Core
{
    public abstract class UIBaseWithStyle<TStyle> : UIBase where TStyle : SO_UIStyle
    {
        [SerializeField] private TStyle _style;

        public TStyle Style { get => _style; private set => _style = value; }

        public void SetStyle(TStyle style)
        {
            Style = style;
            ApplyStyle();
        }
    }
}