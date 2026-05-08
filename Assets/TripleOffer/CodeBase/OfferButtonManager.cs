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
            var offers =
                _offerService.GetAvailableOffers();

            foreach (var offer in offers)
            {
                CreateButton(offer);
            }
        }

        private void CreateButton(IOffer offer)
        {
            OfferUiEntry uiEntry =
                _uiRegistry.Get(offer.Type);

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
            OfferUiEntry uiEntry =
                _uiRegistry.Get(offer.Type);

            OfferWindowView window =
                Instantiate(uiEntry.WindowPrefab);

            window.Setup(offer);
        }
    }
}