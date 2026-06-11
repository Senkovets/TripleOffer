namespace TripleOffer.CodeBase
{
    public class WalletService
    {
        private const string SaveKey = "wallet";
    
        private readonly IEventBus _eventBus;
        private readonly ISaveLoadService _saveLoad;
    
        public int Gems { get; private set; }
        public int Coins { get; private set; }

        public WalletService(IEventBus eventBus, ISaveLoadService saveLoad)
        {
            _eventBus = eventBus;
            _saveLoad = saveLoad;
            Load(); // загружаем при создании
        }

        public void AddGems(int amount)
        {
            Gems += amount;
            Save();
            _eventBus.Publish(new WalletChangedEvent());
        }

        public void AddCoins(int amount)
        {
            Coins += amount;
            Save();
            _eventBus.Publish(new WalletChangedEvent());
        }

        private void Save()
        {
            _saveLoad.Save(SaveKey, new WalletState { Gems = Gems, Coins = Coins });
        }

        private void Load()
        {
            if (!_saveLoad.Exists(SaveKey)) return;
            var state = _saveLoad.Load<WalletState>(SaveKey);
            Gems = state.Gems;
            Coins = state.Coins;
        }
    }
}