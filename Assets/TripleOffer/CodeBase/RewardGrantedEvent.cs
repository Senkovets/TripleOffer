using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    public class RewardGrantedEvent
    {
        public List<RewardData> Rewards;

        public RewardGrantedEvent(List<RewardData> rewards)
        {
            Rewards = rewards;
        }
    }
}