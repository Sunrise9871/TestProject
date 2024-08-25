using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Upgrades
{
    public class UpgradeStore : MonoBehaviour
    {
        private readonly Dictionary<UpgradeItemLogic, UpgradeItemView> _upgradeItemsLogicToView = new();
        
        [SerializeField] private Player.Player _player;
        [SerializeField] private UpgradeStoreData _upgradeStoreData;
        [SerializeField] private UpgradeItemView _upgradeItemView;
        
        private void Awake()
        {
            var upgradeItemsData = _upgradeStoreData.UpgradeItems;
            var playerInventory = _player.UpgradeItemData;
            
            foreach (var upgradeItemData in upgradeItemsData)
            {
                if (playerInventory.Contains(upgradeItemData))
                    continue;
                
                var item = Instantiate(_upgradeItemView, transform);
                item.Initialize(upgradeItemData);
                
                var button = item.BuyLogic;
                _upgradeItemsLogicToView.Add(button, item);
            }
        }

        private void OnEnable()
        {
            foreach (var (itemLogic, _) in _upgradeItemsLogicToView)
                itemLogic.UpgradeItemButtonClicked += OnItemBought;
            
            UpdateButtonsState();
        }
        
        private void OnDisable()
        {
            foreach (var (itemLogic, _) in _upgradeItemsLogicToView)
                itemLogic.UpgradeItemButtonClicked -= OnItemBought;
        }

        private void OnItemBought(UpgradeItemLogic itemLogic)
        {
            var itemData = itemLogic.UpgradeItemData;
            _player.Buy(itemData);

            var itemView = _upgradeItemsLogicToView[itemLogic];
            itemView.gameObject.SetActive(false);
            _upgradeItemsLogicToView.Remove(itemLogic);
            
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            foreach (var (itemLogic, _) in _upgradeItemsLogicToView)
            {
                var itemCost = itemLogic.UpgradeItemData.Cost;
                
                var isEnoughMoney = itemCost <= _player.CoinsAmount;
                itemLogic.SetButtonActive(isEnoughMoney);
            }
        }
    }
}
