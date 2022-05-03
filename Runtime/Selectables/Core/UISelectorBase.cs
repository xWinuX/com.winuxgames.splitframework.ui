using UnityEngine;
using WinuXGames.SplitFramework.UI.Elements.Core;

namespace WinuXGames.SplitFramework.UI.Selectables.Core
{
    public abstract class UISelectorBase : UIBase
    {
        private bool _blocked;

        public void Move(Vector3 position) { OnMove(position); }

        public void Close() => OnClose();
        public void Leave() => OnLeave();
        public void Enter() { OnEnter(); }

        protected virtual void OnMove(Vector3 position) { }
        protected virtual void OnClose()                { }
        protected virtual void OnLeave()                { }
        protected virtual void OnEnter()                { }
    }
}