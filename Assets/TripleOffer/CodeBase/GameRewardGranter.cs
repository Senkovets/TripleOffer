using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class GameRewardGranter
    {
        private readonly Dictionary<Type, IRewardHandler> _handlers;

        public GameRewardGranter(List<IRewardHandler> handlers)
        {
            _handlers = handlers.ToDictionary(x => x.RewardType);
        }

        public void Grant(List<RewardData> rewards)
        {
            foreach (var reward in rewards)
            {
                var type = reward.GetType();

                if (_handlers.TryGetValue(type, out var handler))
                {
                    handler.Grant(reward);
                }
                else
                {
                    Debug.LogError($"No handler for {type}");
                }
            }
        }
    }
}