using System;
using System.Collections.Generic;
using System.Linq;

namespace TripleOffer.CodeBase
{
    [Serializable]
    public class OfferUiEntry
    {
        public string EventId;

        public OfferButtonView ButtonPrefab;

        public OfferWindowView WindowPrefab;

        public List<ItemPrefabEntry> ItemPrefabs;
        
        public OfferItemView GetItemPrefab(
            string itemViewId)
        {
            return ItemPrefabs
                .FirstOrDefault(
                    x => x.ItemViewId == itemViewId)
                ?.Prefab;
        }
    }
}