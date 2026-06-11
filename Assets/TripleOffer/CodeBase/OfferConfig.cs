using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    [System.Serializable]
    public class OfferConfig
    {
        public string EventId;
        public string Type;
        public string Title;
        public float DurationHours;
        
        public string StartDateUtc;  // "2025-01-01T00:00:00Z", null = сразу
        public string EndDateUtc;    // "2025-01-07T00:00:00Z", null = по DurationHours

        public List<OfferItemConfig> Items;
        public List<RewardData> CompletionRewards;
    }
}

