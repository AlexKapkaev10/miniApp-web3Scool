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
            DOTween.Kill(_canvasGroup);
        }

        private void SetVisible(bool isVisible)
        {
            var visibleValue = isVisible ? 1 : 0;

            _canvasGroup?.DOFade(visibleValue, _durationVisible)
                .SetEase(Ease.Linear);
        }
    }

    public enum ViewType
    {
        Character,
        Clicker,
        GameInfo,
        Loader,
        GradientBg
    }
}