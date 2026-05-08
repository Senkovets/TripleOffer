using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class OfferButtonContainer : MonoBehaviour
    {
        [SerializeField] private Transform _container;

        public Transform Container => _container;
    }
}
