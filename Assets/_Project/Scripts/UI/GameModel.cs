using UnityEngine;

namespace _Project.Scripts
{
    public class GameModel
    {
        private readonly GameView _view;

        private const string _saveKey = "saveCount";
        private int _count;
        
        public GameModel(GameView view)
        {
            _view = view;
            _view.Click += OnClick;
            _count = PlayerPrefs.GetInt(_saveKey, 0);
        }

        private void OnClick()
        {
            _count++;
            _view.UpdateTextCount(_count.ToString());
            PlayerPrefs.SetInt(_saveKey, _count);
        }
    }
}