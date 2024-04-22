using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.UI
{
    [CreateAssetMenu(fileName = nameof(ViewsControllerConfig), menuName = "Configs/UI/ViewsControllerConfig")]
    
    public class ViewsControllerConfig : ScriptableObject
    {
        [FormerlySerializedAs("_views")] [SerializeField] private View[] _viewPrefabs;

        public View[] ViewPrefabs => _viewPrefabs;
    }
}