using UnityEngine;

namespace _Project.Scripts.UI
{
    [CreateAssetMenu(fileName = nameof(ViewsStateMachineConfig), menuName = "Configs/UI/StateMachine/ViewsStateMachineConfig")]
    
    public class ViewsStateMachineConfig : ScriptableObject
    {
        [SerializeField] private View[] _viewPrefabs;

        public View[] ViewPrefabs => _viewPrefabs;

        public View GetViewPrefabByType(ViewType type)
        {
            foreach (var prefab in _viewPrefabs)
            {
                if (prefab.ViewType == type)
                    return prefab;
            }

            return null;
        }
    }
}