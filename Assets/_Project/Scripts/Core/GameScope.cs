using _Project.Scripts.Audio;
using _Project.Scripts.Bank;
using _Project.Scripts.Loaders;
using _Project.Scripts.Skills;
using _Project.Scripts.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Core
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private SkillsServiceConfig _skillsServiceConfig;
        [SerializeField] private ViewsControllerConfig _viewsControllerConfig;
        [SerializeField] private AudioControllerConfig _audioControllerConfig; 
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            RegisterBank(builder);
            RegisterServices(builder);
            RegisterFactory(builder);
            RegisterAudioSystem(builder);
            //RegisterLoader(builder);
        }

        private void RegisterLoader(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<ClickerLoader>()
                .As<IClickerLoader>();
        }

        private void RegisterAudioSystem(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<AudioController>()
                .As<IAudioController>()
                .WithParameter(_audioControllerConfig);
        }

        private void RegisterFactory(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<ViewsFactory>()
                .As<IViewsFactory>()
                .WithParameter(_viewsControllerConfig);
        }

        private void RegisterBank(IContainerBuilder builder)
        {
            builder.Register<BankModel>(Lifetime.Singleton)
                .As<IBankModel>();
            builder.Register<BankPresenter>(Lifetime.Singleton)
                .As<IBankPresenter>();
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<SkillsService>(Lifetime.Singleton)
                .As<ISkillsService>()
                .WithParameter(_skillsServiceConfig);
        }
    }
}