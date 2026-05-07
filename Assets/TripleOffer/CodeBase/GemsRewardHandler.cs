namespace TripleOffer.CodeBase
{
    public class GemsRewardHandler : RewardHandler<GemsRewardData>
    {
        private readonly WalletService _wallet;

        public GemsRewardHandler(WalletService wallet)
        {
            _wallet = wallet;
        }

        protected override void GrantTyped(GemsRewardData reward)
        {
            _wallet.AddGems(reward.Amount);
        }
    }
}