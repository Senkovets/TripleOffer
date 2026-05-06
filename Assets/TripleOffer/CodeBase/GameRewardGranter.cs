using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class GameRewardGranter
    {
        private readonly Dictionary<RewardType, IRewardHandler> _handlers;

        public GameRewardGranter(IEnumerable<IRewardHandler> handlers)
        {
            _handlers = handlers.ToDictionary(h => h.SupportedType);
        }

        public void Grant(IEnumerable<RewardData> rewards)
        {
            foreach (var reward in rewards)
            {
                if (_handlers.TryGetValue(reward.Type, out var handler))
                {
                    handler.Grant(reward);
                }
                else
                {
                    Debug.LogWarning($"No handler for reward type: {reward.Type}");
                }
            }
        }
    }
}