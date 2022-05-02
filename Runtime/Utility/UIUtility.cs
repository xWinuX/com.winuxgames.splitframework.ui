using UnityEngine;
using WinuXGames.SplitFramework.UI.Core;

namespace WinuXGames.SplitFramework.UI.Utility
{
    public static class UIUtility
    {
        /// <summary>
        /// Tries to find the top most GameObject with a ICanvas component
        /// </summary>
        /// <param name="start">GameObject from where to search</param>
        /// <returns>Either the found ICanvas or null</returns>
        public static ICanvas TryGetRootCanvas(GameObject start)
        {
            int       safetyExit = 100;
            Transform parent     = start.transform.parent;
            ICanvas   root       = null;
            while (parent != null && safetyExit > 0)
            {
                ICanvas canvasInterface = parent.GetComponent<ICanvas>();
                if (canvasInterface != null) { root = canvasInterface; }

                parent = parent.parent;

                safetyExit--;
            }

            return root;
        }
    }
}