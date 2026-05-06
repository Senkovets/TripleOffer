namespace TripleOffer.CodeBase
{
    public class TripleOffer
    {
        private GameRewardGranter _granter;
        private IEventBus _eventBus;

        public void Purchase(OfferItemConfig item)
        {
            _granter.Grant(item.Rewards);

            _eventBus.Publish(new RewardGrantedEvent(item.Rewards));
        }
    }
}