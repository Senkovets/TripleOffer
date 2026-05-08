using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class TripleOfferWindowView: OfferWindowView
    {
        public override void Setup(IOffer offer)
        {
            Debug.Log(
                $"Open TripleOffer window: {offer.Title}"
            );
        }
    }
    
   
}