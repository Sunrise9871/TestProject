using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Upgrades
{
    public class UpgradeItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _itemName;
        [SerializeField] private TextMeshProUGUI _itemDescription;
        [SerializeField] private TextMeshProUGUI _buttonText;

        [field:SerializeField] public UpgradeItemLogic BuyLogic { get; private set; }
        
        public void Initialize(UpgradeItemData upgradeItemData)
        {
            _image.sprite = upgradeItemData.Sprite;
            _itemName.text = upgradeItemData.Name;
            _itemDescription.text = upgradeItemData.Description;
            _buttonText.text = ValueConverter.ConvertValueToString(upgradeItemData.Cost);

            BuyLogic.Initialize(upgradeItemData);
        }
    }
}
