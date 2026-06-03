using System.Collections.Generic;
using UnityEngine;
using Zenject; 

namespace TripleOffer.CodeBase
{
    public class WindowService : IWindowService
    {
        private readonly OfferUiRegistry _registry;
        private readonly DiContainer _container; 
        
        private readonly Dictionary<string, OfferWindowView> _openedWindows = new();

        public WindowService(OfferUiRegistry registry, DiContainer container) 
        {
            _registry = registry;
            _container = container;
        }

        public void Open(IOffer offer)
        {
            if (_openedWindows.ContainsKey(offer.EventId))
                return;

            OfferUiEntry entry = _registry.Get(offer.EventId);

            if (entry == null)
            {
                Debug.LogError($"WindowService: No registry entry found for {offer.EventId}");
                return;
            }

            OfferWindowView window = _container.InstantiatePrefabForComponent<OfferWindowView>(
                entry.WindowPrefab);

            window.Setup(offer);

            _openedWindows.Add(offer.EventId, window);
        }

        public void Close(OfferWindowView window)
        {
            if (window == null) 
                return;

            if (_openedWindows.ContainsKey(window.EventId))
            {
                _openedWindows.Remove(window.EventId);
            }

            Object.Destroy(window.gameObject);
        }
    }
}