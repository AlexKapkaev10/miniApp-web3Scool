using UnityEngine;
using VContainer;

namespace _Project.Scripts.UI.SwitchViewMenu
{
    public class SwitchViewMenu : MonoBehaviour
    {
        private ISwitchViewItem[] _switchViewItems;
        private IViewsStateMachine _viewsStateMachine;
        
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
            }
        }

        private void ItemOnSwitchView(ViewStateType stateType)
        {
            _viewsStateMachine.SwitchStateByType(stateType);
        }
    }
}