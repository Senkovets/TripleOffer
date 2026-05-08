using System;

namespace TripleOffer.CodeBase
{
    [Serializable]
    public class OfferUiEntry
    {
        public string EventId;

        public OfferButtonView ButtonPrefab;

        public OfferWindowView WindowPrefab;

        public OfferItemView ItemPrefab;
    }
}