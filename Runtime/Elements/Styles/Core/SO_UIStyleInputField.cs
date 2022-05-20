using UnityEngine;

namespace WinuXGames.SplitFramework.UI.Elements.Styles.Core
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Styles/InputField", fileName = "UIStyleInputField", order = 1)]

    public class SO_UIStyleInputField: SO_UIStyleImage<UIInputField>
    {
        [SerializeField] private SO_UIStyleText _textStyle;
        [SerializeField] private SO_UIStyleText _textStylePlaceholder;

        public override void Apply(UIInputField element)
        {
            base.Apply(element);
            
            element.Text.SetStyle(_textStyle);
            element.TextPlaceholder.SetStyle(_textStylePlaceholder);
        }
    }
}