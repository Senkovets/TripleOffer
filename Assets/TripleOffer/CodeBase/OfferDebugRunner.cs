using UnityEngine;
using Zenject;

namespace TripleOffer.CodeBase
{
    public class OfferDebugRunner : MonoBehaviour
    {
        [Inject] private IOfferService _offerService;

        private void Start()
        {
            var offers = _offerService.GetAvailableOffers();

            foreach (var offer in offers)
            {
                Debug.Log($"Offer: {offer.Title}");

                foreach (var item in offer.Items)
                {
                    Debug.Log($"Buying: {item.Id}");

                    var result = offer.Purchase(item.Id);

                    Debug.Log(result.Type);
                }
            }
        }
    }
}