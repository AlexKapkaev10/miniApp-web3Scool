using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.UI
{
    public interface IViewsFactory
    {
        void CreateViews();
    }
    
    public class ViewsFactory : MonoBehaviour, IViewsFactory
    {
        private ViewsControllerConfig _config;
        private IObjectResolver _resolver;

        [Inject]
        private void Construct(IObjectResolver resolver, ViewsControllerConfig config)
        {
            _resolver = resolver;
            _config = config;
        }

        private void Awake()
        {

        }

        public void CreateViews()
        {
            transform.SetParent(null);
            foreach (var prefab in _config.ViewPrefabs)
            {
                _resolver.Instantiate(prefab, transform);
            }
        }
    }
}