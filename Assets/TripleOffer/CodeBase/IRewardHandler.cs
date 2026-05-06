namespace TripleOffer.CodeBase
{
    public interface IRewardHandler
    {
        RewardType SupportedType { get; }
        void Grant(RewardData reward);
    }
}