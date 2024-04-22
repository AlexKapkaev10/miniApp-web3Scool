using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class GameView : MonoBehaviour
    {
        public event Action Click;
    
        [SerializeField] private Button _buttonClick;
        [SerializeField] private TMP_Text _textCount;

        private void Awake()
        {
            var model = new GameModel(this);
            _buttonClick.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Click?.Invoke();
        }

        public void UpdateTextCount(string countValue)
        {
            _textCount.SetText(countValue);
        }
    }
}

