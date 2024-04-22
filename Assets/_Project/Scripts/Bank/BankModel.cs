using System;
using UnityEngine;

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

        private int _gameCoinCount;
        private const string _saveKey = "saveGameCoinCount";

        public int GameCoinCount => _gameCoinCount;

        public BankModel()
        {
            _gameCoinCount = PlayerPrefs.GetInt(_saveKey, 0);
        }

        public void SetGameCoins(int value)
        {
            _gameCoinCount += value;
            PlayerPrefs.SetInt(_saveKey, _gameCoinCount);
            GameCoinValueChange?.Invoke(_gameCoinCount);
        }
    }
}