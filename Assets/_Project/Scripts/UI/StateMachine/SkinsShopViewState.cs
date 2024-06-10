using System.Collections.Generic;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.UI.StateMachine
{
    public class SkinsShopViewState : IViewState
    {
        private readonly List<View> _views = new List<View>();
        private readonly ViewsStateMachineConfig _config;
        private readonly IObjectResolver _resolver;

        public SkinsShopViewState(IObjectResolver resolver, ViewsStateMachineConfig config)
        {
            _config = config;
            _resolver = resolver;
        }
        
        public void Enter()
        {
            var shop = _resolver.Instantiate(_config.GetViewPrefabByType(ViewType.SkinsShop), null);
            var character = _resolver.Instantiate(_config.GetViewPrefabByType(ViewType.Character), null);
            _views.Add(shop);
            _views.Add(character);
        }

        public void Exit()
        {
            foreach (var view in _views)
            {
                view.SetDisable();
            }
            
            _views.Clear();
        }
    }
}