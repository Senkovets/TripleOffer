using UnityEngine;

namespace TripleOffer.CodeBase
{
    public abstract class OfferWindowView : MonoBehaviour
    {
        public string EventId { get; protected set; }

        public virtual void Setup(IOffer offer)
        {
            EventId = offer.EventId;
        }

    }
}