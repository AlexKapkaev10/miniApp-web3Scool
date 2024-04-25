using _Project.Scripts.Audio;
using _Project.Scripts.Bank;
using TMPro;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.UI
{
    public class ClickerView : View
    {
        [SerializeField] private Coin _coin;
        [SerializeField] private TMP_Text _textCoinCount;
        
        private IBankModel _bankModel = default;
        private IBankPresenter _bankPresenter = default;
        private IAudioController _audioController = default;
        
        [Inject]
        private void Construct(
            IBankModel bankModel, 
            IAudioController audioController, 
            IBankPresenter bankPresenter)
        {
            _bankModel = bankModel;
            _audioController = audioController;
            _bankPresenter = bankPresenter;
        }

        private void Awake()
        {
            _audioController.SetFxClip(SoundMode.ClickCoin);
            _audioController.SetAmbientClip(SoundMode.ClickerAmbient);
            _audioController.PlayAmbientClip();
        }
        
        private void OnEnable()
        {
            _textCoinCount.SetText(_bankModel.GameCoinCount.ToString());
            _bankPresenter.GameCoinValueChange += UpdateCoinsText;
            _coin.ClickItem += CoinOnCoinClick;
        }

        private void OnDisable()
        {
            _bankPresenter.GameCoinValueChange -= UpdateCoinsText;
            _coin.ClickItem -= CoinOnCoinClick;
        }

        private void UpdateCoinsText(string textCoinCount)
        {
            _textCoinCount.SetText(textCoinCount);
        }

        private void CoinOnCoinClick()
        {
            _bankModel.SetGameCoins(1);
            _audioController.PlayFXClip();
            _coin.ClickAnimation();
        }
    }
}