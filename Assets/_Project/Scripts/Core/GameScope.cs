using _Project.Scripts.Audio;
using _Project.Scripts.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Core
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private ViewsStateMachineConfig _viewsStateMachineConfig;
        [SerializeField] private AudioControllerConfig _audioControllerConfig; 
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            
            RegisterFactory(builder);
            RegisterAudioSystem(builder);
        }

        private void RegisterAudioSystem(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<AudioController>()
                .As<IAudioController>()
                .WithParameter(_audioControllerConfig);
        }

        private void RegisterFactory(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<ViewsStateMachine>()
                .As<IViewsStateMachine>()
                .WithParameter(_viewsStateMachineConfig);
        }
    }
}