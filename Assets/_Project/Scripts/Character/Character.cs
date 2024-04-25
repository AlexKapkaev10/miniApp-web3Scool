using _Project.Scripts.Character.Skin;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Scripts.Character
{
    public interface ICharacter
    {
        
    }
    
    public class Character : MonoBehaviour, ICharacter, IPointerClickHandler
    {
        [SerializeField] private CharacterSkin _skinPrefab;
        private ICharacterSkin _characterSkin;

        private void Awake()
        {
            _characterSkin = Instantiate(_skinPrefab, transform);
            
            var animationData = new AnimationData
            {
                ColorFrom = new Color(0.79f, 0.5f, 1f),
                ColorTo = new Color(0.57f, 0.3f, 1f),
                PlayOnAwake = true,
                ClickAnimationCount = 2,
                ScaleAnimationTimeLoop = 1f,
                ScaleAnimationOffset = new Vector3(0.1f, 0f,0f),
                ScaleAnimationEase = Ease.Linear,
                
            };
            
            _characterSkin.Initialize(animationData);
        }

        private void OnDisable()
        {
            _characterSkin.StopLoopAnimation();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _characterSkin.PlayClickAnimation();
        }
    }
}