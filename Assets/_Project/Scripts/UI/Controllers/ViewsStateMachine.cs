using System.Collections.Generic;
using _Project.Scripts.UI.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.UI
{
    public interface IViewsStateMachine
    {
        void CreateViews();
        void SwitchStateByType(ViewStateType type);
    }
    
    public class ViewsStateMachine : MonoBehaviour, IViewsStateMachine
    {
        private Dictionary<ViewStateType, IViewState> _dictionaryStates;
        private ViewsStateMachineConfig _config = default;
        private IObjectResolver _resolver = default;
        private IViewState _currentViewState = default;
        private ViewStateType _currentStateType = ViewStateType.None;

        [Inject]
        private void Construct(IObjectResolver resolver, ViewsStateMachineConfig config)
        {
            _resolver = resolver;
            _config = config;
        }

        private void Awake()
        {
            CreateMachine();
        }

        public void CreateViews()
        {
            transform.SetParent(null);
            foreach (var prefab in _config.ViewPrefabs)
            {
                _resolver.Instantiate(prefab, transform);
            }
        }

        public void SwitchStateByType(ViewStateType type)
        {
            if (_currentStateType == type)
            {
                return;
            }
            
            if (_currentViewState != null)
            {
                _currentViewState.Exit();
                _currentViewState = null;
                _currentStateType = ViewStateType.None;
            }

            if (!_dictionaryStates.TryGetValue(type, out IViewState viewState))
            {
                return;
            }

            _currentStateType = type;
            _currentViewState = viewState;
            _currentViewState.Enter();
        }

        private void CreateMachine()
        {
            _dictionaryStates = new Dictionary<ViewStateType, IViewState>
            {
                { ViewStateType.Home , new HomeViewState(_resolver, _config)},
                { ViewStateType.Activity , new ActivityViewState(_resolver, _config)}
            };
        }
    }

    public enum ViewStateType
    {
        None,
        Home,
        Activity
    }
}