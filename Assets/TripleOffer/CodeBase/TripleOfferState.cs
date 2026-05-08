using System;
using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    public class TripleOfferState
    {
        public HashSet<string> PurchasedItems =
            new HashSet<string>();
        
        //либо   public List<string> PurchasedItems = new();?
        public bool CompletionRewardClaimed;

        public bool Completed;

        public DateTime StartTime;

        public DateTime ExpirationTime;
    }
}