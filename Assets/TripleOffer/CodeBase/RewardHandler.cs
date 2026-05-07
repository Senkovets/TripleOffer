namespace TripleOffer.CodeBase
{
    public abstract class RewardHandler<TReward> : IRewardHandler
        where TReward : RewardData
    {
        public System.Type RewardType => typeof(TReward);

        public void Grant(RewardData reward)
        {
            GrantTyped((TReward)reward);
        }

        protected abstract void GrantTyped(TReward reward);
    }
}