using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements;
using WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Core;
using WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Image;
using WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Text;

namespace WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Button
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Select Behaviours/Button", fileName = "UIButtonSelectBehaviour", order = 0)]
    public class SO_UIButtonSelectBehaviour : SO_UISelectBehaviour<UIButton> 
    {
        [SerializeField] private SO_UIImageSelectBehaviour _imageSelectBehaviour;
        [SerializeField] private SO_UITextSelectBehaviour  _textSelectBehaviour;

        public override void OnSelect(UIButton element)
        {
            if (_imageSelectBehaviour != null) { _imageSelectBehaviour.OnSelect(element.Image); }
            if (_textSelectBehaviour != null) { _textSelectBehaviour.OnSelect(element.Text); }
        }

        public override void OnDeselect(UIButton element)
        {
            if (_imageSelectBehaviour != null) { _imageSelectBehaviour.OnDeselect(element.Image); }
            if (_textSelectBehaviour != null) { _textSelectBehaviour.OnDeselect(element.Text); }
        }
    }
}