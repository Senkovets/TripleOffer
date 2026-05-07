using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class SkinRewardHandler : RewardHandler<SkinRewardData>
    {
        protected override void GrantTyped(SkinRewardData reward)
        {
            UnityEngine.Debug.Log($"Unlocked skin {reward.SkinId}");
        }
    }
}