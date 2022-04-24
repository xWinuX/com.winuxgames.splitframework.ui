using TMPro;
using UnityEngine;
using WinuXGames.SplitFramework.UI.Scripts.ScriptableObjects;

namespace WinuXGames.SplitFramework.UI.Scripts.Interfaces
{
    public class UITextInterface : UIInterface<SO_UIStyleText>
    {
        [SerializeField] private TMP_Text _text;

        public TMP_Text Text => _text;

        public void SetText(string text) { _text.text = text; }

        protected override void ApplyStyle()
        {
            Style.Apply(_text, RootCanvasInterface.Style.RenderMode, RootCanvasInterface.Style.ReferencePixelPerUnit);
        }
    }
}