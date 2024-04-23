using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class FlyEffect : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _flyValue = 100f;
        [SerializeField] private float _flyDuration = 1.2f;
        
        public void Fly(Vector2 startPosition)
        {
            Destroy(gameObject, _flyDuration + 0.05f);
            _rectTransform.position = startPosition;
            _rectTransform.DOMoveY(_flyValue, _flyDuration)
                .SetEase(Ease.Linear)
                .SetRelative(true);
            _canvasGroup.DOFade(0, _flyDuration)
                .SetEase(Ease.Linear);
        }

        private void OnDestroy()
        {
            DOTween.Kill(_rectTransform);
            DOTween.Kill(_canvasGroup);
        }
    }
}