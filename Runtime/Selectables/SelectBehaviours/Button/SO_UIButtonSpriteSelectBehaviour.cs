using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements;

namespace WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Button
{
    [CreateAssetMenu(menuName = "Split Framework/UI/SelectBehaviours/Button/Sprite", fileName = "UIButtonSpriteSelectionBehaviour", order = 0)]
    public class SO_UIButtonSpriteSelectBehaviour : SO_UIButtonSelectBehaviour
    {
        [SerializeField] private Sprite _selectedSprite;

        public override void OnSelect(UIButton element) { element.Image.sprite = _selectedSprite; }

        public override void OnDeselect(UIButton element) { element.Image.sprite = element.Style.Sprite; }
    }
}