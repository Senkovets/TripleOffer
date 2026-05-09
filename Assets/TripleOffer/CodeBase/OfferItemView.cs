using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TripleOffer.CodeBase
{
    public class OfferItemView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Button _buyButton;

        private OfferItemConfig _config;
        private IOffer _offer;

        public void Setup(
            OfferItemConfig config,
            IOffer offer)
        {
            _config = config;
            _offer = offer;

            Debug.Log("AddListener");
            _buyButton.onClick.AddListener(Buy);
        }

        private void Buy()
        {
            Debug.Log("Buy");
            PurchaseResult result =
                _offer.Purchase(_config.Id);

            Debug.Log(result.Type);
        }
    }
}