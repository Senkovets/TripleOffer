using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class SkinRewardHandler : RewardHandler<SkinRewardData>
    {
        private readonly ProfileService _profile;
        public SkinRewardHandler(ProfileService profile) => _profile = profile;

        protected override void GrantTyped(SkinRewardData reward) => _profile.AddSkin(reward.SkinId);
    }
}