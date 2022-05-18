using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using WinuXGames.SplitFramework.Core;

namespace WinuXGames.SplitFramework.UI.Selectables.Core
{
    public interface ISelectable : IGameObject
    {
        Vector3                   GetSelectorPosition();
        UnityEvent<BaseEventData> OnSelectUnityEvent { get; }
    }
}