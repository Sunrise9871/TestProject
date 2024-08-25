using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private readonly List<UpgradeItemData> _upgradeItemData = new();
        
        [SerializeField] private long _coinsAmount;

        public ReadOnlyCollection<UpgradeItemData> UpgradeItemData => _upgradeItemData.AsReadOnly();

        public long CoinsAmount => _coinsAmount;

        public event Action<long> CoinsAmountChanged;

        public void Buy(UpgradeItemData upgradeItemData)
        {
            if (_coinsAmount < upgradeItemData.Cost)
                throw new InvalidOperationException();

            _coinsAmount -= upgradeItemData.Cost;
            CoinsAmountChanged?.Invoke(_coinsAmount);
            
            _upgradeItemData.Add(upgradeItemData);
        }
    }
}