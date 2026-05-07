using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    public interface IConfigService
    {
        List<OfferConfig> LoadOffers();
    }
}