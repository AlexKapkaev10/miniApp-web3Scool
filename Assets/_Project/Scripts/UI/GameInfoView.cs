using TMPro;
using UnityEngine;

namespace _Project.Scripts
{
    public interface IGameInfoView
    {
        void UpdateCoinsText(string coinsText);
    }
    
    public class GameInfoView : MonoBehaviour, IGameInfoView
    {
        [SerializeField] private TMP_Text _textCoins;

        public void UpdateCoinsText(string coinsText)
        {
            _textCoins.SetText(coinsText);
        }
    }
}

