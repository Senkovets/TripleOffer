using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TripleOffer.CodeBase
{
    public class RewardPopupView : MonoBehaviour
    {
        [SerializeField] private Transform _contentRoot;
        [SerializeField] private RewardItemView _itemPrefab;
        [SerializeField] private Button _okButton;

        private readonly List<RewardItemView> _items = new();

        private void Awake()
        {
            _okButton.onClick.AddListener(Hide);
        }

        public void Show(List<RewardData> rewards)
        {
            gameObject.SetActive(true);

            Clear();

            foreach (var reward in rewards)
            {
                var item = Instantiate(_itemPrefab, _contentRoot);
                item.Setup(reward);
                _items.Add(item);
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            Clear();
        }

        private void Clear()
        {
            foreach (var item in _items)
            {
                Destroy(item.gameObject);
            }

            _items.Clear();
        }
    }
}