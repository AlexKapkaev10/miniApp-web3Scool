using System;
using _Project.Scripts.UI;

namespace _Project.Scripts.Bank
{
    public interface IBankPresenter
    {
        event Action<string> GameCoinValueChange;
        void SetView(IGameInfoView view);
        void CheckUpdate();
    }
    
    public class BankPresenter : IBankPresenter
    {
        public event Action<string> GameCoinValueChange;
        
        private readonly IBankModel _model;
        private IGameInfoView _view;
        
        public BankPresenter(IBankModel model)
        {
            _model = model;
            _model.GameCoinValueChange += OnGameCoinValueChange;
        }

        private void OnGameCoinValueChange(int value)
        {
            GameCoinValueChange?.Invoke(value.ToString());
        }

        public void SetView(IGameInfoView view)
        {
            _view = view;
        }

        public void CheckUpdate()
        {
            _view?.UpdateCoinsText(_model.GameCoinCount.ToString());
        }
    }
}