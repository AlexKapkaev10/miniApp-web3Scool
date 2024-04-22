using System.Collections;
using _Project.Scripts.Audio;
using _Project.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Project.Scripts.Loaders
{
    public interface IClickerLoader
    {
        
    }
    
    public class ClickerLoader : View
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _loadSimulationSpeed = 0.002f;
        
        private IAudioController _audioController;
        private IViewsFactory _viewsFactory;
        
        [Inject]
        private void Construct(IAudioController audioController, IViewsFactory viewsFactory)
        {
            _audioController = audioController;
            _viewsFactory = viewsFactory;
        }

        private void Awake()
        {
            StartCoroutine(LoadSimulationAsync());
        }

        private IEnumerator LoadSimulationAsync()
        {
            while (_slider.value < 1)
            {
                _slider.value += _loadSimulationSpeed;
                yield return null;
            }

            _viewsFactory.CreateViews();
            _audioController.SetFxClip(SoundMode.ClickCoin);
            _audioController.SetAmbientClip(SoundMode.ClickerAmbient);
            _audioController.PlayAmbientClip();
            Destroy(gameObject);
        }
    }
}