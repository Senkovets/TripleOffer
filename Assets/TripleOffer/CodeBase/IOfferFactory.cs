namespace TripleOffer.CodeBase
{
    public interface IOfferFactory
    {
        IOffer Create(OfferConfig config);
    }
}