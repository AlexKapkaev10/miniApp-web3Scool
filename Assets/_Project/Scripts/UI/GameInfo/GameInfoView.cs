using _Project.Scripts.Bank;
using TMPro;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.UI
{
    public interface IGameInfoView
    {
        void UpdateCoinsText(string coinsText);
    }
    
    public class GameInfoView : View, IGameInfoView
    {
        [SerializeField] private TMP_Text _textCoins;
        
        private IBankPresenter _presenter;

        [Inject]
        private void Construct(IBankPresenter presenter)
        {
            _presenter = presenter;
            _presenter.SetView(this);
        }

        private void OnEnable()
        {
            _presenter.CheckUpdate();
            _presenter.GameCoinValueChange += UpdateCoinsText;
        }

        private void OnDisable()
        {
            _presenter.GameCoinValueChange -= UpdateCoinsText;
        }

        public void UpdateCoinsText(string coinsText)
        {
            _textCoins.SetText(coinsText);
        }
    }
}

