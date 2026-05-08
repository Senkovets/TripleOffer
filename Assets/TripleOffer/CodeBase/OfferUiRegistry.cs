using System.Collections.Generic;
using UnityEngine;

namespace TripleOffer.CodeBase
{
    [CreateAssetMenu(
        menuName = "Offer System/Offer UI Registry"
    )]
    public class OfferUiRegistry : ScriptableObject
    {
        public List<OfferUiEntry> Entries;

        public OfferUiEntry Get(string eventId)
        {
            return Entries.Find(x => x.EventId == eventId);
        }
    }
}

