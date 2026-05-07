namespace TripleOffer.CodeBase
{
    public class CoinsRewardHandler : RewardHandler<CoinsRewardData>
    {
        private readonly WalletService _wallet;

        public CoinsRewardHandler(WalletService wallet)
        {
            _wallet = wallet;
        }

        protected override void GrantTyped(CoinsRewardData reward)
        {
            _wallet.AddCoins(reward.Amount);
        }
    }
}