using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WinuXGames.SplitFramework.UI.Core;
using WinuXGames.SplitFramework.UI.Elements.Core;
using WinuXGames.SplitFramework.UI.Selectables.Core;

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

        /// <summary>
        /// Configures given navigation mode for given selectables
        /// </summary>
        /// <param name="selectables">Selectables to configure</param>
        /// <param name="navigationMode">Navigation mode to configure for</param>
        /// <exception cref="ArgumentOutOfRangeException">Invalid NavigationMode Enum was passed</exception>
        public static void ConfigureNavigation(List<UISelectable> selectables, NavigationMode navigationMode)
        {
            for (int i = 0; i < selectables.Count; i++)
            {
                Selectable selectable = selectables[i];

                Navigation navigation = selectable.navigation;
                navigation.mode = Navigation.Mode.Explicit;

                switch (navigationMode)
                {
                    case NavigationMode.Horizontal:
                        navigation.selectOnLeft  = i == 0 ? selectables[^1] : selectables[i - 1];
                        navigation.selectOnRight = i == selectables.Count - 1 ? selectables[0] : selectables[i + 1];
                        break;
                    case NavigationMode.Vertical:
                        navigation.selectOnUp   = i == 0 ? selectables[^1] : selectables[i - 1];
                        navigation.selectOnDown = i == selectables.Count - 1 ? selectables[0] : selectables[i + 1];
                        break;
                    default: throw new ArgumentOutOfRangeException(nameof(navigationMode), navigationMode, null);
                }

                selectable.navigation = navigation;
            }
        }
    }
}