using UnityEngine;

namespace TripleOffer.CodeBase
{
    public abstract class OfferWindowView : MonoBehaviour
    {
        public abstract void Setup(IOffer offer);
    }
}