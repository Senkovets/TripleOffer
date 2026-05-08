using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using TripleOffer.CodeBase;

namespace TripleOffer.CodeBase
{
    public class OfferButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;

        [SerializeField] private Button _button;

        private IOffer _offer;

        public event Action<IOffer> Clicked;

        public void Setup(IOffer offer)
        {
            _offer = offer;

            _title.text = offer.Title;

            _button.onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            Clicked?.Invoke(_offer);
        }
    }
}