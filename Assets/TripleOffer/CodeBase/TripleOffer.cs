namespace TripleOffer.CodeBase
{
    using System.Collections.Generic;
    using System.Linq;

    public class TripleOffer : IOffer
    {
        private readonly OfferConfig _config;
        private readonly GameRewardGranter _rewardGranter;

        private readonly TripleOfferState _state;

        public string EventId => _config.EventId;

        public string Type => _config.Type;

        public string Title => _config.Title;

        public bool IsAvailable => true;

        public List<OfferItemConfig> Items => _config.Offers;

        public TripleOffer(
            OfferConfig config,
            GameRewardGranter rewardGranter)
        {
            _config = config;
            _rewardGranter = rewardGranter;

            _state = new TripleOfferState();
        }

        public void Initialize()
        {
        }

        public PurchaseResult Purchase(string itemId)
        {
            if (_state.PurchasedItems.Contains(itemId))
            {
                return PurchaseResult.Failed(
                    "Already purchased"
                );
            }

            OfferItemConfig item =
                _config.Offers.FirstOrDefault(x => x.Id == itemId);

            if (item == null)
            {
                return PurchaseResult.Failed(
                    "Item not found"
                );
            }

            _rewardGranter.Grant(item.Rewards);

            _state.PurchasedItems.Add(itemId);

            return PurchaseResult.Success();
        }
    }
}