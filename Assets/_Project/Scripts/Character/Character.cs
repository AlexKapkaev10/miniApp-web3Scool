using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Scripts.Character
{
    public interface ICharacter
    {
        
    }
    
    public class Character : MonoBehaviour, ICharacter, IPointerDownHandler
    {
        [SerializeField] private Color _colorTo;
        [SerializeField] private Image _image;
        
        private Transform _transform;
        
        private void Awake()
        {
            _transform = transform;
        }

        private void OnEnable()
        {
            SetLoopAnimation(true);
        }

        private void OnDisable()
        {
            SetLoopAnimation(false);
        }

        private void SetLoopAnimation(bool isPlay)
        {
            if (isPlay)
            {
                _transform.DOScaleX(1.1f, 1f)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Yoyo);
                
                _image.DOColor(_colorTo, 1f)
                    .SetEase(Ease.Linear)
                    .SetLoops(-1, LoopType.Yoyo);
            }
            else
            {
                DOTween.Kill(_transform);
                DOTween.Kill(_image);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            SetLoopAnimation(false);
        }
    }
}