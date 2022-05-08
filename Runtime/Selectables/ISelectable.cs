using UnityEngine;
using WinuXGames.SplitFramework.Core;

namespace WinuXGames.SplitFramework.UI.Selectables
{
    public interface ISelectable : IGameObject
    {
        Vector3 GetSelectorPosition();
    }
}