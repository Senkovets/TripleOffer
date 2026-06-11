using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

namespace TripleOffer.CodeBase
{
    public class OfferButtonView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _timerText; // Добавь поле для текста таймера
        [SerializeField] private Button _button;

        private IOffer _offer;
        public event Action<IOffer> Clicked;

        public void Setup(IOffer offer)
        {
            _offer = offer;
            _title.text = offer.Title;
        
            _button.onClick.RemoveAllListeners(); // Безопаснее чистить перед добавлением
            _button.onClick.AddListener(OnClicked);

            StopAllCoroutines();
            StartCoroutine(UpdateTimerRoutine());
        }

        private IEnumerator UpdateTimerRoutine()
        {
            while (_offer != null)
            {
                if (!_offer.IsAvailable)
                {
                    gameObject.SetActive(false); // прячем кнопку
                    yield break;
                }
        
                _timerText.text = _offer.RemainingTimeStr;
                yield return new WaitForSeconds(1f);
            }
        }

        private void OnClicked() => Clicked?.Invoke(_offer);
    }
}