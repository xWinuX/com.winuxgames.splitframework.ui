using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements;

namespace WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours
{
    [CreateAssetMenu(menuName = "Split Framework/UI/SelectBehaviours/Text/Color", fileName = "UITextColorSelectionBehaviour", order = 0)]
    public class SO_UITextColorSelectBehaviour : SO_UITextSelectBehaviour
    {
        [SerializeField] private Color _color = Color.white;

        public override void OnSelect(UIText element) { element.Text.color = _color; }

        public override void OnDeselect(UIText element) { element.Text.color = element.Style.Color; }
    }
}