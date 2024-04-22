using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.Audio
{
    public interface IAudioController
    {
        void SetFxClip(in SoundMode mode);
        void SetAmbientClip(in SoundMode clip);
        void PlayFXClip();
        void PlayAmbientClip();
    }
    
    public sealed class AudioController : MonoBehaviour, IAudioController
    {
        [SerializeField] private AudioSource _audioSourceFX;
        [SerializeField] private AudioSource _audioSourceAmbient;
        
        private AudioControllerConfig _config;

        [Inject]
        private void Construct(AudioControllerConfig config)
        {
            _config = config;
            _config.InitConfig();
        }
        
        public void SetFxClip(in SoundMode mode)
        {
            _audioSourceFX.clip = _config.GetClipByMode(mode);
        }
        
        public void SetAmbientClip(in SoundMode mode)
        {
            _audioSourceAmbient.clip = _config.GetClipByMode(mode);
        }

        public void PlayFXClip()
        {
            _audioSourceFX.Play();
        }
        
        public void PlayAmbientClip()
        {
            _audioSourceAmbient.volume = 0f;
            _audioSourceAmbient.loop = true;
            _audioSourceAmbient.Play();
            _audioSourceAmbient.DOFade(0.7f, 5f)
                .SetEase(Ease.Linear);
        }
    }
}