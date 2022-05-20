using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Elements.Styles.Core;

namespace WinuXGames.SplitFramework.UI.Elements.Core
{
    public abstract class UIWithImage<TElement, TStyle> : UIBaseWithStyle<TElement, TStyle> 
        where TElement : UIBase 
        where TStyle : SO_UIStyle<TElement>
    {
        [SerializeField] private Image _image;

        public Image Image => _image;
    }

}