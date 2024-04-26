using System;
using _Project.Scripts.SaveLoad;
using VContainer;

namespace _Project.Scripts.Bank
{
    public interface IBankModel
    {
        event Action<int> GameCoinValueChange;
        int GameCoinCount { get; }
        void SetGameCoins(int value);
    }

    public class BankModel : IBankModel
    {
        public event Action<int> GameCoinValueChange;

        private readonly ISaveLoadService _saveLoadService;
        private int _gameCoinCount;

        public int GameCoinCount => _gameCoinCount;

        [Inject]
        public BankModel(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _gameCoinCount = _saveLoadService.LoadCoinsCount();
        }

        public void Initialize()
        {
            
        }

        public void SetGameCoins(int value)
        {
            _gameCoinCount += value;
            _saveLoadService.SaveCoinsCount(value);
            GameCoinValueChange?.Invoke(_gameCoinCount);
        }
    }
}