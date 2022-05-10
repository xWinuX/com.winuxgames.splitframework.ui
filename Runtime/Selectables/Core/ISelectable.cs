using UnityEngine;
using WinuXGames.SplitFramework.Core;

namespace WinuXGames.SplitFramework.UI.Selectables.Core
{
    public interface ISelectable : IGameObject
    {
        Vector3 GetSelectorPosition();
    }
}