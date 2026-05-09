using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TripleOffer.CodeBase
{
    public class OfferButtonManager: MonoBehaviour, IOfferButtonManager
    {
        [SerializeField]
        private OfferButtonContainer _container;

        [SerializeField]
        private OfferUiRegistry _uiRegistry;

        [Inject]
        private IOfferService _offerService;

        [Inject]
        private IWindowService _windowService;

        public void Start()
        {
            Build();
        }

        public void Build()
        {
            var offers = _offerService.GetAvailableOffers();

            foreach (var offer in offers)
            {
                CreateButton(offer);
            }
        }

        private void CreateButton(IOffer offer)
        {
            OfferUiEntry uiEntry =
                _uiRegistry.Get(offer.EventId);
            
            // Если в реестре нет настроек для этого типа оффера
            if (uiEntry == null)
            {
                Debug.LogError($"[OfferButtonManager] No UI Entry found for offer type: {offer.Type}");
                return;
            }

            // Если ты забыл назначить префаб в самом реестре
            if (uiEntry.ButtonPrefab == null)
            {
                Debug.LogError($"[OfferButtonManager] ButtonPrefab is missing in UI Entry for: {offer.Type}");
                return;
            }

            // Если забыл назначить контейнер в инспекторе
            if (_container == null || _container.Container == null)
            {
                Debug.LogError("[OfferButtonManager] Container or Container.Transform is null! Check Inspector.");
                return;
            }

            OfferButtonView button =
                Instantiate(
                    uiEntry.ButtonPrefab,
                    _container.Container
                );

            button.Setup(offer);

            button.Clicked += OpenOffer;
        }

        private void OpenOffer(IOffer offer)
        {
            _windowService.Open(offer);
            
            /*OfferUiEntry uiEntry =
                _uiRegistry.Get(offer.EventId);

            OfferWindowView window =
                Instantiate(uiEntry.WindowPrefab);
            
            List<OfferItemConfig> Items = offer.Items;
            
            foreach (var aitem in Items)
            {
                Instantiate(uiEntry.ItemPrefab, window.transform);
            }

            window.Setup(offer);*/
        }
    }
}