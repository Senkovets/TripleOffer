using System.Collections.Generic;
using System.Linq;

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
        }

        public List<IOffer> GetAvailableOffers()
        {
            return _offers
                .Where(x => x.IsAvailable)
                .ToList();
        }
    }
}