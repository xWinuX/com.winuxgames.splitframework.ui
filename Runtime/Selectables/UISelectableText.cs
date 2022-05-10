using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements;
using WinuXGames.SplitFramework.UI.Extensions;
using WinuXGames.SplitFramework.UI.Selectables.Core;
using WinuXGames.SplitFramework.UI.Selectables.SelectBehaviours.Text;

namespace WinuXGames.SplitFramework.UI.Selectables
{
    public class UISelectableText : UISelectableWithBehaviour<UIText, SO_UITextSelectBehaviour>
    {
        [SerializeField] private Vector3 _selectorOffset = Vector3.zero;
        
        private readonly Vector3[] _corners = new Vector3[4];
        
        
        public override Vector3 GetSelectorPosition()
        {
            if (RectTransform == null) { return transform.position; }
            
            return RectTransform.GetCenterLeftPosition(_corners) + _selectorOffset;
        }
    }
}