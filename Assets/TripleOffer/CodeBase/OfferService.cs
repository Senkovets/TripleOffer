using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class OfferService : IOfferService
    {
        private readonly List<IOffer> _offers;

        public OfferService(
            IConfigService configService,
            IOfferFactory offerFactory)
        {
            _offers = configService
                .LoadOffers()
                .Select(offerFactory.Create)
                .ToList();

            foreach (var offer in _offers)
            {
                offer.Initialize();
            }
            
            
            foreach (var offer in _offers)
            {
                Debug.Log(
                    $"{offer.EventId} available: {offer.IsAvailable}"
                );
            }
        }

        public List<IOffer> GetAvailableOffers()
        {
            foreach (var offer in _offers)
            {
                Debug.Log(
                    $"{offer.EventId} available: {offer.IsAvailable}"
                );
            }
            
            return _offers
                .Where(x => x.IsAvailable)
                .ToList();
        }
    }
}