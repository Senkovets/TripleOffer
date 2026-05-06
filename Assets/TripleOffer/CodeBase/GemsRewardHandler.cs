namespace TripleOffer.CodeBase
{
    public class GemsRewardHandler : IRewardHandler
    {
        private readonly WalletService _wallet;

        public RewardType SupportedType => RewardType.Gems;

        public GemsRewardHandler(WalletService wallet)
        {
            _wallet = wallet;
        }

        public void Grant(RewardData reward)
        {
            _wallet.AddGems(reward.Amount);
        }
    }
}