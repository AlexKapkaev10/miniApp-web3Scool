namespace _Project.Scripts.Skills
{
    public interface ISkillsService
    {
        SkillData[] SkillsData { get; }
    }
    
    public class SkillsService : ISkillsService
    {
        private readonly SkillsServiceConfig _config;

        public SkillData[] SkillsData => _config.SkillsData;
        
        public SkillsService(SkillsServiceConfig config)
        {
            _config = config;
        }
    }
}