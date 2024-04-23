using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.SwitchViewMenu
{
    public interface ISwitchViewItem
    {
        event Action<ViewStateType> SwitchView;
    }
    
    public class SwitchViewItem : MonoBehaviour, ISwitchViewItem
    {
        public event Action<ViewStateType> SwitchView;
        
        [SerializeField] private Button _button;
        [SerializeField] private ViewStateType _stateType;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            SwitchView?.Invoke(_stateType);
        }
    }
}