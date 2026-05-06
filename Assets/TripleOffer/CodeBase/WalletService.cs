namespace TripleOffer.CodeBase
{
    public class WalletService
    {
        private int _gems;

        public void AddGems(int amount)
        {
            _gems += amount;
            UnityEngine.Debug.Log($"Gems +{amount}, total: {_gems}");
        }
    }
}