namespace TripleOffer.CodeBase
{
    public class WalletService
    {
        private readonly IEventBus _eventBus;
        public int Gems { get; private set; }
        public int Coins { get; private set; }

        public WalletService(IEventBus eventBus) => _eventBus = eventBus;
        public void AddGems(int amount)
        {
            Gems += amount;
            _eventBus.Publish(new WalletChangedEvent());
            UnityEngine.Debug.Log($"Gems +{amount}, total: {Gems}");
        }

        public void AddCoins(int amount)
        {
            Coins += amount;
            _eventBus.Publish(new WalletChangedEvent());
            UnityEngine.Debug.Log($"Coins +{amount}, total: {Coins}");
        }
    }
}