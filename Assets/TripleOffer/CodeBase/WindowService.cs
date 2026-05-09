using UnityEngine;
using Zenject; 

namespace TripleOffer.CodeBase
{
    public class WindowService : IWindowService
    {
        private readonly OfferUiRegistry _registry;
        private readonly DiContainer _container; 

        public WindowService(OfferUiRegistry registry, DiContainer container) 
        {
            _registry = registry;
            _container = container;
        }

        public void Open(IOffer offer)
        {
            OfferUiEntry entry = _registry.Get(offer.EventId);
            
            // Используем Zenject вместо обычного Instantiate
            OfferWindowView window = _container
                .InstantiatePrefabForComponent<OfferWindowView>(entry.WindowPrefab);
            
            window.Setup(offer);
        }

        public void Close(OfferWindowView window)
        {
            Object.Destroy(window.gameObject);
        }
    }
}