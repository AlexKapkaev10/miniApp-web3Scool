using _Project.Scripts.Bank;
using _Project.Scripts.Skills;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Core
{
    public class ProjectScope : LifetimeScope
    {
        
        [SerializeField] private SkillsServiceConfig _skillsServiceConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            RegisterServices(builder);
            RegisterBank(builder);
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