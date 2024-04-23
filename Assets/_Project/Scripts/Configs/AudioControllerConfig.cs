using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Audio
{
    [CreateAssetMenu(fileName = nameof(AudioControllerConfig), menuName = "Configs/Audio/AudioControllerConfig")]
    public class AudioControllerConfig : ScriptableObject
    {
        [field: SerializeField] public AudioClip ClickCoinClip { get; private set; }
        [field: SerializeField] public AudioClip ClickerAmbientClip { get; private set; }
        
        private Dictionary<SoundMode, AudioClip> _audioClipDictionary;

        public void InitConfig()
        {
            _audioClipDictionary = new Dictionary<SoundMode, AudioClip>
            {
                { SoundMode.ClickCoin, ClickCoinClip },
                { SoundMode.ClickerAmbient, ClickerAmbientClip }
            };
        }

        public AudioClip GetClipByMode(SoundMode mode)
        {
            return _audioClipDictionary.TryGetValue(mode, out AudioClip clip) ? clip : null;
        }
    }

    public enum SoundMode
    {
        Home,
        ClickCoin,
        ClickerAmbient
    }
}