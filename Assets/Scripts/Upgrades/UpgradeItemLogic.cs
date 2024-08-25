using System;
using Buttons;
using ScriptableObjects;
using UnityEngine;

namespace Upgrades
{
    [RequireComponent(typeof(CustomButton))]
    public class UpgradeItemLogic : MonoBehaviour
    {
        private CustomButton _physicalButton;
        public UpgradeItemData UpgradeItemData { get; private set; }
        
        public event Action<UpgradeItemLogic> UpgradeItemButtonClicked;

        public void Initialize(UpgradeItemData upgradeItemData) => UpgradeItemData = upgradeItemData;

        public void SetButtonActive(bool state) => _physicalButton.interactable = state;
        
        private void Awake() => _physicalButton = GetComponent<CustomButton>();

        private void OnEnable() => _physicalButton.OnReleaseClick += OnClick;
        
        private void OnDisable() => _physicalButton.OnReleaseClick -= OnClick;
        
        private void OnClick()
        {
            if (_physicalButton.IsInteractable())
                UpgradeItemButtonClicked?.Invoke(this);
        } 
    }
}