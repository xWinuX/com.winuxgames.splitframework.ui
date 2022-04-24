using UnityEngine;

namespace WinuXGames.SplitFramework.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class UIInterface : MonoBehaviour
    {
        public RectTransform RectTransform { get; private set; }

        protected virtual void Awake() { RectTransform = GetComponent<RectTransform>(); }
    }
}