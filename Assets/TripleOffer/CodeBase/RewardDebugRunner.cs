using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TripleOffer.CodeBase
{
    public class RewardDebugRunner : MonoBehaviour
    {
        [Inject] private GameRewardGranter _granter;

        private void Start()
        {
            var rewards = new List<RewardData>
            {
                new RewardData { Type = RewardType.Gems, Amount = 100 },
                new RewardData { Type = RewardType.PremiumDays, Days = 2 },
                new RewardData { Type = RewardType.Skin, SkinId = "hero_1" }
            };

            _granter.Grant(rewards);
        }
    }
}