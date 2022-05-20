using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements;
using WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Core;
using WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Image;
using WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Text;

namespace WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.InputField
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Select Behaviours/InputField", fileName = "UIInputFieldSelectBehaviour", order = 0)]
    public class SO_UIInputFieldSelectBehaviour : SO_UISelectBehaviour<UIInputField>
    {
        [SerializeField] private SO_UIImageSelectBehaviour _imageSelectBehaviour;
        [SerializeField] private SO_UITextSelectBehaviour  _textSelectBehaviour;
        [SerializeField] private SO_UITextSelectBehaviour  _textPlaceholderSelectBehaviour;

        public override void OnSelect(UIInputField element)
        {
            if (_imageSelectBehaviour != null) { _imageSelectBehaviour.OnSelect(element.Image); }
            if (_textSelectBehaviour != null) { _textSelectBehaviour.OnSelect(element.Text); }
            if (_textPlaceholderSelectBehaviour != null) { _textPlaceholderSelectBehaviour.OnSelect(element.TextPlaceholder); }
        }

        public override void OnDeselect(UIInputField element)
        {
            if (_imageSelectBehaviour != null) { _imageSelectBehaviour.OnDeselect(element.Image); }
            if (_textSelectBehaviour != null) { _textSelectBehaviour.OnDeselect(element.Text); }
            if (_textPlaceholderSelectBehaviour != null) { _textPlaceholderSelectBehaviour.OnDeselect(element.TextPlaceholder); }
        }
    }
}