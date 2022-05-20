using UnityEngine;

namespace WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Image
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Select Behaviours/Image/Sprite Swap", fileName = "UIImageSpriteSwapSelectBehaviour", order = 0)]
    public class SO_UIImageSpriteSwapSelectBehaviour : SO_UIImageSelectBehaviour
    {
        [SerializeField] private Sprite _sprite;
        
        public override void OnSelect(UnityEngine.UI.Image   element) { element.overrideSprite = _sprite; }
        public override void OnDeselect(UnityEngine.UI.Image element) { element.overrideSprite = null; }
    }
}