using _Project.Scripts.Audio;
using _Project.Scripts.UI;
using VContainer;

namespace _Project.Scripts.Character
{
    public class CharacterView : View
    {
        private IAudioController _audioController;
        
        [Inject]
        private void Construct(IAudioController audioController)
        {
            _audioController = audioController;
        }

        private void Awake()
        {
            _audioController.SetAmbientClip(SoundMode.Home);
        }
    }
}