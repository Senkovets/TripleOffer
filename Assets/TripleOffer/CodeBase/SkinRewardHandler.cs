using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class SkinRewardHandler : IRewardHandler
    {
        public RewardType SupportedType => RewardType.Skin;

        public void Grant(RewardData reward)
        {
            Debug.Log($"Unlocked skin: {reward.SkinId}");
        }
    }
}