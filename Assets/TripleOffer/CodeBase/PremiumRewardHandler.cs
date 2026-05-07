using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class PremiumRewardHandler : RewardHandler<PremiumRewardData>
    {
        protected override void GrantTyped(PremiumRewardData reward)
        {
            UnityEngine.Debug.Log($"Premium for {reward.Days} days");
        }
    }
}