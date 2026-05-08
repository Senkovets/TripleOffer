namespace TripleOffer.CodeBase
{
    public class PurchaseResult
    {
        public PurchaseResultType Type;

        public string Message;

        public static PurchaseResult Success()
        {
            return new PurchaseResult
            {
                Type = PurchaseResultType.Success
            };
        }

        public static PurchaseResult Failed(string message)
        {
            return new PurchaseResult
            {
                Type = PurchaseResultType.Failed,
                Message = message
            };
        }
    }
}