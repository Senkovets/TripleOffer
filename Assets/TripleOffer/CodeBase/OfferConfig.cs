using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    [System.Serializable]
    public class OfferConfig
    {
        public string EventId;
        public string Type;

        public string Title;

        public int DurationHours;

        public List<OfferItemConfig> Items;
        public List<RewardData> CompletionRewards;
    }
}

