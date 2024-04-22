using System;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public class Coin : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private FlyEffect _flyEffectPrefab;

        public event Action CoinClick;
        private Transform _transform;
        private Tweener _tweener;

        private void Awake()
        {
            _transform = transform;
        }
        

        public void ClickAnimation()
        {
            if (_tweener != null)
                return;

            _tweener = _transform
                .DOScale(1.1f, 0.05f)
                .SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.Linear)
                .OnComplete(() => _tweener = null);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            CoinClick?.Invoke();
            var flyEffect = Instantiate(_flyEffectPrefab, eventData.position, quaternion.identity);
            flyEffect.transform.SetParent(transform, true);
            flyEffect.Fly();
        }
    }
}