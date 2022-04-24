using UnityEngine;
using UnityEngine.UI;

namespace WinuXGames.SplitFramework.UI.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Styles/Canvas", fileName = "UIStyleCanvas", order = 0)]
    public class SO_UIStyleCanvas : SO_UIStyle
    {
        [SerializeField] private int        _referencePixelPerUnit;
        [SerializeField] private RenderMode _renderMode;

        public RenderMode RenderMode            => _renderMode;
        public int        ReferencePixelPerUnit => _referencePixelPerUnit;

        public void Apply(Canvas canvas, CanvasScaler scaler)
        {
            canvas.renderMode               = _renderMode;
            canvas.additionalShaderChannels = AdditionalCanvasShaderChannels.TexCoord1;
            scaler.uiScaleMode              = CanvasScaler.ScaleMode.ConstantPixelSize;
            scaler.dynamicPixelsPerUnit     = 1;
            scaler.referencePixelsPerUnit   = _referencePixelPerUnit;
        }
    }
}