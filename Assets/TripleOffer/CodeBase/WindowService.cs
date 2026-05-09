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

        // DiContainer уже зарегистрирован в самом Zenject, 
        // поэтому он просто придет сюда через конструктор.
        public WindowService(OfferUiRegistry registry, DiContainer container) 
        {
            _registry = registry;
            _container = container;
        }

        public void Open(IOffer offer)
        {
            if (_openedWindows.ContainsKey(offer.EventId))
            {
                return;
            }

            OfferUiEntry entry = _registry.Get(offer.EventId);

            if (entry == null)
            {
                Debug.LogError($"WindowService: No registry entry found for {offer.EventId}");
                return;
            }

            // ИСПРАВЛЕНИЕ: Используем контейнер для спавна префаба.
            // Это автоматически прокинет [Inject] IWindowService и OfferUiRegistry в само окно.
            OfferWindowView window = _container.InstantiatePrefabForComponent<OfferWindowView>(
                entry.WindowPrefab);

            // Теперь Setup вызовется у объекта, в котором зависимости уже внедрены.
            window.Setup(offer);

            _openedWindows.Add(offer.EventId, window);
        }

        public void Close(OfferWindowView window)
        {
            // Небольшая проверка на null, чтобы не упасть при закрытии
            if (window == null) return;

            if (_openedWindows.ContainsKey(window.EventId))
            {
                _openedWindows.Remove(window.EventId);
            }

            Object.Destroy(window.gameObject);
        }
    }
}