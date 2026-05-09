using UnityEngine;

namespace TripleOffer.CodeBase
{
    public interface IWindowService
    {
        void Open(IOffer offer);
        void Close(OfferWindowView window);
    }
}