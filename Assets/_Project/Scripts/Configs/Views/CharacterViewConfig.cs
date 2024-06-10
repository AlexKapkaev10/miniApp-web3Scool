using _Project.Scripts.GameCharacter;
using _Project.Scripts.UI;
using UnityEngine;

namespace _Project.Scripts.Configs.Views
{
    [CreateAssetMenu(fileName = nameof(CharacterViewConfig), menuName = "Configs/Views/CharacterViewConfig")]
    public class CharacterViewConfig : ScriptableObject
    {
        [field: SerializeField] public ActionButton ActionButtonPrefab { get; private set; }
        [field: SerializeField] public Character CharacterPrefab { get; private set; }
    }
}