namespace TripleOffer.CodeBase
{
    public class WalletService
    {
        public int Gems { get; private set; }
        public int Coins { get; private set; }

        public void AddGems(int amount)
        {
            Gems += amount;
            UnityEngine.Debug.Log($"Gems +{amount}, total: {Gems}");
        }

        public void AddCoins(int amount)
        {
            Coins += amount;
            UnityEngine.Debug.Log($"Coins +{amount}, total: {Coins}");
        }
    }
  
}