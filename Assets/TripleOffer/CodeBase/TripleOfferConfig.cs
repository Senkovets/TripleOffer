using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    public class TripleOfferConfig
    {
        public string EventId;
        public int DurationHours;

        public List<OfferItemConfig> Offers;
        public List<RewardData> CompletionReward; // полиморфный список
    }
}