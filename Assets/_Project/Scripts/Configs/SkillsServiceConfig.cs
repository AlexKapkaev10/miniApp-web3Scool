using System;
using UnityEngine;

namespace _Project.Scripts.Skills
{
    [CreateAssetMenu(fileName = nameof(SkillsServiceConfig), menuName = "Configs/Services/SkillsServiceConfig")]
    public class SkillsServiceConfig : ScriptableObject
    {
        [field: SerializeField] public SkillData[] SkillsData { get; private set; }
    }

    [Serializable]
    public struct SkillData
    {
        public SkillType Type;
        public string LocalizationKey;
    }

    public enum SkillType
    {
        Intellect,
        FinLiteracy
    }
}