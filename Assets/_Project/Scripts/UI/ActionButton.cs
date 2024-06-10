using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public interface IActionButton
    {
        void SetActive(bool isActive, float duration = 0.25f);
    }
    
    public class ActionButton : MonoBehaviour, IActionButton
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup.alpha = 0f;
        }

        public void SetActive(bool isActive, float duration = 0.25f)
        {
            var visibleValue = isActive ? 1f : 0f;

            _canvasGroup.DOFade(visibleValue, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    if (!isActive)
                    {
                        Destroy(gameObject);
                    }
                });
        }
    }
}