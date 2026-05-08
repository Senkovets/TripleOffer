using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TripleOffer.CodeBase
{
    public class OfferItemView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Button _buy;

        private string _id;

        public void Setup(OfferItemConfig data, System.Action<string> onBuy)
        {
            _id = data.Id;

            _title.text = data.Id; // пока так
            _price.text = data.Price.ToString();

            _buy.onClick.RemoveAllListeners();
            _buy.onClick.AddListener(() => onBuy?.Invoke(_id));
        }
    }
}