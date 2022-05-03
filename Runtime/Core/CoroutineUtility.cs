using System;
using System.Collections;
using UnityEngine;

namespace WinuXGames.SplitFramework.Core
{
    static internal class CoroutineUtility
    {
        public static IEnumerator WaitForOneFrame(Action action)
        {
            yield return new WaitForEndOfFrame();
            action.Invoke();
        }
    }
}