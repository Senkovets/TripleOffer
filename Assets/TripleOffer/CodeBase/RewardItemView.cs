using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TripleOffer.CodeBase
{
    public class RewardItemView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _title;

        public void Setup(RewardData reward)
        {
            switch (reward.Type)
            {
                case RewardType.Gems:
                    _title.text = $"+{reward.Amount} Gems";
                    break;

                case RewardType.PremiumDays:
                    _title.text = $"+{reward.Days} Days Premium";
                    break;

                case RewardType.Skin:
                    _title.text = $"Skin: {reward.SkinId}";
                    break;
            }

            // icon можно пока захардкодить или сделать позже через registry
        }
    }
}