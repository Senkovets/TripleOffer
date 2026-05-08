using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    public interface IOffer
    {
        string EventId { get; }

        string Type { get; }

        string Title { get; }

        bool IsAvailable { get; }

        List<OfferItemConfig> Items { get; }

        void Initialize();

        PurchaseResult Purchase(string itemId);
    }
}