using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class PremiumRewardHandler : RewardHandler<PremiumRewardData>
    {
        private readonly ProfileService _profile;
        public PremiumRewardHandler(ProfileService profile) => _profile = profile;

        protected override void GrantTyped(PremiumRewardData reward) => _profile.AddPremium(reward.Days);
    }
}