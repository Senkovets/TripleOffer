namespace TripleOffer.CodeBase
{
    public interface IRewardHandler
    {
        System.Type RewardType  { get; }
        void Grant(RewardData reward);
    }
}