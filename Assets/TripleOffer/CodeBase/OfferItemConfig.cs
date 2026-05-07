using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    public class OfferItemConfig
    {
        public string Id;

        public string Title;

        public float Price;

        public List<RewardData> Rewards;       // полиморфный список
    }
}