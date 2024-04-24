using System;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class View : MonoBehaviour
    {
        [field: SerializeField] public ViewType ViewType { get; private set; }
        
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _durationVisible = 0.4f;
        [SerializeField] private bool _ignoreSetVisible = false;

        private Tween _tweener;

        protected virtual void Start()
        {
            if (_ignoreSetVisible)
            {
                return;
            }
            _canvasGroup.alpha = 0f;
            SetVisible(true);
        }

        protected virtual void OnDestroy()
        {
            if (_tweener != null)
            {
                DOTween.Kill(_tweener);
            }
        }

        private void SetVisible(bool isVisible)
        {
            var visibleValue = isVisible ? 1 : 0;

            _tweener = _canvasGroup?.DOFade(visibleValue, _durationVisible)
                .SetEase(Ease.Linear)
                .OnComplete(()=> _tweener = null);
        }
    }

    public enum ViewType
    {
        None,
        Character,
        Clicker,
        GameInfo,
        Loader,
        GradientBg
    }
}