using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Logic
{
    public class UpgradeItemGraphics : MonoBehaviour
    {
        
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _itemName;
        [SerializeField] private TextMeshProUGUI _itemDescription;

        [SerializeField] private GameObject _activeButton;
        [SerializeField] private TextMeshProUGUI _activeButtonText;

        [SerializeField] private GameObject _inactiveButton;
        [SerializeField] private TextMeshProUGUI _inactiveButtonText;

        public void FillInfo(Sprite sprite, string itemName, string description, long cost)
        {
            _image.sprite = sprite;
            _itemName.text = itemName;
            _itemDescription.text = description;

            var costText = CostConverter.ConvertCostToString(cost);

            _activeButtonText.text = costText;
            _inactiveButtonText.text = costText;
        }

        
    }
}
