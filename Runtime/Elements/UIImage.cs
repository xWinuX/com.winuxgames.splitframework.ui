using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Elements.Core;

namespace WinuXGames.SplitFramework.UI.Elements
{
    [ExecuteAlways]
    public class UIImage : UIBase
    {
        [SerializeField] private Image _image;
        [SerializeField] private int   _scale;

        public int Scale { get => _scale; set => _scale = value; }

        private Sprite _currentSprite;

        protected override void Awake() { _currentSprite = _image.sprite; }

        protected override void Update()
        {
            base.Update();

            #if UNITY_EDITOR
            UpdateSize();
            #endif
        }

        private void LateUpdate()
        {
            if (_currentSprite != _image.sprite) { UpdateSize(); }
        }
        
        private void UpdateSize()
        {
            if (_image.type is Image.Type.Sliced or Image.Type.Tiled) { return; }

            _image.SetNativeSize();
            Vector2 currentSize = _image.rectTransform.sizeDelta;
            _image.rectTransform.sizeDelta = new Vector2(currentSize.x * _scale, currentSize.y * _scale);
            _currentSprite                 = _image.sprite;
        }
    }
}