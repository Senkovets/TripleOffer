using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class PremiumRewardHandler : IRewardHandler
    {
        public RewardType SupportedType => RewardType.PremiumDays;

        public void Grant(RewardData reward)
        {
            Debug.Log($"Premium +{reward.Days} days");
        }
    }
}