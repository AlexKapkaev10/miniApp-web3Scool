using _Project.Scripts.Audio;
using _Project.Scripts.Configs.Views;
using _Project.Scripts.Skills;
using _Project.Scripts.UI;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.GameCharacter
{
    public class CharacterView : View
    {
        [SerializeField] private CharacterViewConfig _config;
        [SerializeField] private RectTransform _characterParent;

        private IActionButton _skillUpgradeButton;
        private IAudioController _audioController;
        private ISkillsService _skillsService;
        private ICharacter _character;
        
        [Inject]
        private void Construct(IAudioController audioController, ISkillsService skillsService)
        {
            _audioController = audioController;
            _audioController.SetFxClip(AudioMode.CharacterClick);
            _character = Instantiate(_config.CharacterPrefab, _characterParent);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _character.Click += OnClickCharacter;
        }

        private void OnDisable()
        {
            _character.Click -= OnClickCharacter;
        }

        private void OnClickCharacter()
        {
            _audioController.PlayFXClip();
            if (_skillUpgradeButton == null)
            {
                _skillUpgradeButton = Instantiate(_config.ActionButtonPrefab, transform);
                _skillUpgradeButton.SetActive(true);
            }
            else
            {
                _skillUpgradeButton.SetActive(false);
                _skillUpgradeButton = null;
            }
        }

        private void Awake()
        {
            _audioController.SetAmbientClip(AudioMode.Home);
        }
    }
}