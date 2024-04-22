using _Project.Scripts.Skills;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Core
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private SkillsServiceConfig _skillsServiceConfig;
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            RegisterServices(builder);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<SkillsService>(Lifetime.Singleton)
                .As<ISkillsService>()
                .WithParameter(_skillsServiceConfig);
        }
    }
}