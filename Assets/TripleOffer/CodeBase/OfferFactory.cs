namespace TripleOffer.CodeBase
{
    public class OfferFactory : IOfferFactory
    {
        private readonly GameRewardGranter _rewardGranter;

        public OfferFactory(
            GameRewardGranter rewardGranter)
        {
            _rewardGranter = rewardGranter;
        }

        public IOffer Create(OfferConfig config)
        {
            switch (config.Type)
            {
                case "TripleOffer":
                    return new TripleOffer(
                        config,
                        _rewardGranter
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