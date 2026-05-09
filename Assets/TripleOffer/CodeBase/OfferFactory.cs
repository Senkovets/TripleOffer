namespace TripleOffer.CodeBase
{
    public class OfferFactory : IOfferFactory
    {
        private readonly GameRewardGranter _rewardGranter;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IClock _clock;
        private readonly IEventBus _eventBus;

        public OfferFactory(
            GameRewardGranter rewardGranter,
            ISaveLoadService saveLoadService,
            IClock clock,
            IEventBus eventBus)
        {
            _rewardGranter = rewardGranter;
            _saveLoadService = saveLoadService;
            _clock = clock;
            _eventBus = eventBus;
            
        }

        public IOffer Create(OfferConfig config)
        {
            switch (config.Type)
            {
                case "TripleOffer":
                    return new TripleOffer(
                        config,
                        _rewardGranter,
                        _saveLoadService,
                        _clock,
                        _eventBus
                    );

                default:
                    UnityEngine.Debug.LogError(
                        $"Unknown offer type {config.Type}"
                    );

                    return null;
            }
        }
    }
}