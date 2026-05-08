using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    public interface IOfferService
    {
        List<IOffer> GetAvailableOffers();
    }
}