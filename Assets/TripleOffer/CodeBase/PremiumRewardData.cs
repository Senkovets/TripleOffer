using Newtonsoft.Json;

namespace TripleOffer.CodeBase
{
    [JsonObject]
    public class PremiumRewardData : RewardData
    {
        public int Days;
    }
}