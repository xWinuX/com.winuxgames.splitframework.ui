using UnityEngine;
using WinuXGames.SplitFramework.UI.Interfaces;

namespace WinuXGames.SplitFramework.UI.ScriptableObjects.SelectBehaviour
{
    [CreateAssetMenu(menuName = "Split Framework/UI/SelectBehaviours/Text/Color", fileName = "UITextColorSelectionBehaviour", order = 0)]
    public class UITextColorSelectBehaviour : UITextSelectBehaviour
    {
        [SerializeField] private Color _color = Color.white;

        public override void OnSelect(IUIText element) { element.Text.color = _color; }

        public override void OnDeselect(IUIText element) { element.Text.color = element.Style.Color; }
    }
}