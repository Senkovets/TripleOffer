using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    public interface IOffer
    {
        string EventId { get; }

        string Type { get; }

        string Title { get; }

        bool IsAvailable { get; }

        bool IsCompleted { get; }

        List<OfferItemConfig> Items { get; }

        void Initialize();

        void Save();
        
        bool IsPurchased(string itemId);

        PurchaseResult Purchase(string itemId);
    }
}