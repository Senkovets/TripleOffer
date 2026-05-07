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
            switch (reward)
            {
                case GemsRewardData gems:
                    _title.text = $"+{gems.Amount} Gems";
                    break;

                case CoinsRewardData coins:
                    _title.text = $"+{coins.Amount} Coins";
                    break;

                case PremiumRewardData premium:
                    _title.text = $"+{premium.Days} Days Premium";
                    break;

                case SkinRewardData skin:
                    _title.text = $"Skin: {skin.SkinId}";
                    break;

                default:
                    _title.text = "Unknown Reward";
                    break;
            }
        }
    }
}