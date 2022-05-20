using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Elements.Styles.Core;

namespace WinuXGames.SplitFramework.UI.Elements.Styles
{
    [CreateAssetMenu(menuName = "Split Framework/UI/Styles/Canvas", fileName = "UIStyleCanvas", order = 0)]
    public class SO_UIStyleCanvas : SO_UIStyle<UICanvas>
    {
        [SerializeField] private Vector2Int _referenceResolution;

        [SerializeField] private int        _referencePixelPerUnit;
        [SerializeField] private RenderMode _renderMode;

        public RenderMode RenderMode            => _renderMode;
        public int        ReferencePixelPerUnit => _referencePixelPerUnit;
        public Vector2Int ReferenceResolution   => _referenceResolution;

        public override void Apply(UICanvas canvas)
        {
            canvas.Canvas.renderMode                   = _renderMode;
            canvas.Canvas.pixelPerfect                 = true;
            canvas.Canvas.additionalShaderChannels     = AdditionalCanvasShaderChannels.TexCoord1;
            canvas.CanvasScaler.uiScaleMode            = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvas.CanvasScaler.referenceResolution    = _referenceResolution;
            canvas.CanvasScaler.dynamicPixelsPerUnit   = 1;
            canvas.CanvasScaler.referencePixelsPerUnit = _renderMode == RenderMode.WorldSpace ? 1 : _referencePixelPerUnit;
        }
    }
}