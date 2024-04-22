using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class View : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _durationVisible = 0.4f;
        [SerializeField] private bool _ignoreSetVisible = false;

        private void Start()
        {
            if (_ignoreSetVisible)
            {
                return;
            }
            _canvasGroup.alpha = 0f;
            SetVisible(true);
        }

        private void SetVisible(bool isVisible)
        {
            var visibleValue = isVisible ? 1 : 0;

            _canvasGroup?.DOFade(visibleValue, _durationVisible)
                .SetEase(Ease.Linear);
        }
    }
}