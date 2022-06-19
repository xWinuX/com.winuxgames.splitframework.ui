using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WinuXGames.SplitFramework.Core;

namespace WinuXGames.SplitFramework.UI.Selectables.Core
{
    public interface ISelectable : IGameObject
    {
        Selectable                Selectable { get; }
        Vector3                   GetSelectorPosition();
        UnityEvent<BaseEventData> OnSelectUnityEvent { get; }
        UnityEvent                OnSubmitUnityEvent { get; }
    }
}