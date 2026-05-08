namespace TripleOffer.CodeBase
{
    using System.Collections.Generic;
    using System.Linq;

    public class TripleOffer : IOffer
    {
        private readonly OfferConfig _config;
        private readonly GameRewardGranter _rewardGranter;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IClock _clock;

        private TripleOfferState _state; 

        public string EventId => _config.EventId;

        public string Type => _config.Type;

        public string Title => _config.Title;

        public bool IsAvailable =>
            !_state.Completed &&
            _clock.UtcNow < _state.ExpirationTime;
        
        public bool IsCompleted =>
            _state.Completed;

        public List<OfferItemConfig> Items => _config.Offers;

        public TripleOffer(
            OfferConfig config,
            GameRewardGranter rewardGranter,
            ISaveLoadService saveLoadService,
            IClock clock)
        {
            _config = config;
            _rewardGranter = rewardGranter;
            _saveLoadService = saveLoadService;
            _clock = clock;

            _state = new TripleOfferState();
        }

        public void Initialize()
        {
            LoadOrCreateState();
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

            CheckCompletion();

            Save();

            return PurchaseResult.Success();
        }
        
        public void Save()
        {
            string key =
                OfferSaveKeys.GetOfferKey(EventId);

            _saveLoadService.Save(key, _state);
        }
        
        private void LoadOrCreateState()
        {
            string key =
                OfferSaveKeys.GetOfferKey(EventId);

            if (_saveLoadService.Exists(key))
            {
                _state = _saveLoadService.Load<TripleOfferState>(key);

                return;
            }

            _state = new TripleOfferState
            {
                StartTime = _clock.UtcNow,
                ExpirationTime =
                    _clock.UtcNow.AddHours(
                        _config.DurationHours
                    )
            };

            Save();
        }
        
        private void CheckCompletion()
        {
            bool allPurchased =
                _config.Offers.All(
                    x => _state.PurchasedItems.Contains(x.Id)
                );

            if (!allPurchased)
            {
                return;
            }

            _state.Completed = true;

            GrantCompletionReward();
        }
        
        private void GrantCompletionReward()
        {
            if (_state.CompletionRewardClaimed)
            {
                return;
            }

            _rewardGranter.Grant(
                _config.CompletionRewards
            );

            _state.CompletionRewardClaimed = true;
        }
    }
}