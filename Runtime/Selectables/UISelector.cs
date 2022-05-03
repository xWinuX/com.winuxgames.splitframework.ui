using DG.Tweening;
using UnityEngine;
using WinuXGames.SplitFramework.UI.Selectables.Core;

namespace WinuXGames.SplitFramework.UI.Selectables
{
    public class UISelector : UISelectorBase
    {
        private Tween _moveTween;

        private void Start() { transform.DOPunchScale(Vector3.one * 2f, 1f); }

        private void OnDestroy() { transform.DOKill(); }

        protected override void OnMove(Vector3 position)
        {
            _moveTween?.Kill();
            _moveTween = transform.DOMove(position, 0.125f).SetEase(Ease.OutBack);
        }

        protected override    void OnEnter() { transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutElastic); }
        protected override void OnLeave() { transform.DOScale(Vector3.one * 0.25f, 1f).SetEase(Ease.OutElastic); }
        protected override void OnClose() { Destroy(gameObject); }
    }
}