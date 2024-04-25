using UnityEngine;
using VContainer;

namespace _Project.Scripts.UI.SwitchViewMenu
{
    public class SwitchViewMenu : MonoBehaviour
    {
        [SerializeField] private ViewStateType _defaultType = ViewStateType.Home;
        private ISwitchViewItem[] _switchViewItems;
        private IViewsStateMachine _viewsStateMachine;
        private ISwitchViewItem _currentItem;
        
        [Inject]
        private void Construct(IViewsStateMachine viewsStateMachine)
        {
            _viewsStateMachine = viewsStateMachine;
        }

        private void Awake()
        {
            _switchViewItems = GetComponentsInChildren<ISwitchViewItem>();

            foreach (var item in _switchViewItems)
            {
                item.SwitchView += ItemOnSwitchView;
                if (item.Type == _defaultType)
                {
                    _currentItem = item;
                }
            }
        }

        private void Start()
        {
            if (_currentItem != null)
            {
                ItemOnSwitchView(_currentItem);
            }
        }

        private void ItemOnSwitchView(ISwitchViewItem item)
        {
            _viewsStateMachine.SwitchStateByType(item.Type);
        }
    }
}