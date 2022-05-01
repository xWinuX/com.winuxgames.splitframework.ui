using UnityEngine;

namespace WinuXGames.SplitFramework.UI.Extensions
{
    public static class CanvasExtension
    {
        public static Matrix4x4 GetCanvasMatrix(this Canvas canvas)
        {
            RectTransform rectTr       = (RectTransform)canvas.transform;
            Matrix4x4     canvasMatrix = rectTr.localToWorldMatrix;
            canvasMatrix *= Matrix4x4.Translate(-rectTr.sizeDelta / 2);
            return canvasMatrix;
        }
    }
}