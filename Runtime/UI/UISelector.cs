using DG.Tweening;
using UnityEngine;
using WinuXGames.SplitFramework.UI.UI.Core;

namespace WinuXGames.SplitFramework.UI.UI
{
    public class UISelector : UISelectorBase
    {
        private Tween _moveTween;

        protected override void ApplyStyle()
        {
            base.ApplyStyle();
            transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f).SetEase(Ease.OutBack).SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }

        public override void Move(Vector3 position)
        {
            _moveTween?.Kill();
            _moveTween = transform.DOMove(position, 0.125f).SetEase(Ease.OutBack);
        }
    }
}