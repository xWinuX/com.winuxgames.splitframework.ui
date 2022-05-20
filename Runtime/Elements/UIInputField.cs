using TMPro;
using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Elements.Styles.Core;

namespace WinuXGames.SplitFramework.UI.Elements
{
    public class UIInputField : UIWithImage<UIInputField, SO_UIStyleInputField>, IImage
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private UIText         _text;
        [SerializeField] private UIText         _textPlaceholder;
        
        public UIText         Text            => _text;
        public UIText         TextPlaceholder => _textPlaceholder;
    }
}