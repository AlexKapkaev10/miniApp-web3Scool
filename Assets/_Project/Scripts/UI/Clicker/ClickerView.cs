using _Project.Scripts.Audio;
using _Project.Scripts.Bank;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.UI
{
    public class ClickerView : View
    {
        [SerializeField] private Coin _coin;
        
        private IBankModel _bankModel;
        private IAudioController _audioController;
        
        [Inject]
        private void Construct(IBankModel bankModel, IAudioController audioController)
        {
            _bankModel = bankModel;
            _audioController = audioController;
        }

        private void Awake()
        {
            _coin.ClickItem += CoinOnCoinClick;
            _audioController.SetFxClip(SoundMode.ClickCoin);
            _audioController.SetAmbientClip(SoundMode.ClickerAmbient);
            _audioController.PlayAmbientClip();
        }

        private void OnDisable()
        {
            _coin.ClickItem -= CoinOnCoinClick;
        }

        private void CoinOnCoinClick()
        {
            _bankModel.SetGameCoins(1);
            _audioController.PlayFXClip();
            _coin.ClickAnimation();
        }
    }
}