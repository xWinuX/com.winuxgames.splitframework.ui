using UnityEngine;

namespace WinuXGames.SplitFramework.UI.Extensions
{
    public static class RectTransformExtensions
    {
        public static Vector3 GetCenterLeftPosition(this RectTransform rectTransform, Vector3[] corners)
        {
            rectTransform.GetWorldCorners(corners);
            
            return (corners[0] + corners[1]) / 2 ;
        }
    }
}