using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TripleOffer.CodeBase
{
    public class RewardDebugRunner : MonoBehaviour
    {
        [Inject] private GameRewardGranter _granter;
        [Inject] private IEventBus _eventBus;

        private void Start()
        {
            var rewards = new List<RewardData>
            {
                new RewardData { Type = RewardType.Gems, Amount = 100 },
                new RewardData { Type = RewardType.PremiumDays, Days = 2 },
                new RewardData { Type = RewardType.Skin, SkinId = "hero_1" }
            };
            
            var testOffer = new OfferItemConfig
            {
                Id = "starter_pack_01",
                Price = 4.99f,
                Rewards = rewards
            };

            Purchase(testOffer);
            
        }
        
        public void Purchase(OfferItemConfig item)
        {
            Debug.Log($"[DebugRunner] Buying item: {item.Id}");
            _granter.Grant(item.Rewards);

            _eventBus.Publish(new RewardGrantedEvent(item.Rewards));
        }
    }
}