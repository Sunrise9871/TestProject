using TMPro;
using UnityEngine;
using Utils;

namespace UI
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private TextMeshProUGUI _walletUIText;

        private void Awake() => SetWalletText(_player.CoinsAmount);

        private void OnEnable() => _player.CoinsAmountChanged += OnCoinsAmountChanged;

        private void OnDisable() => _player.CoinsAmountChanged -= OnCoinsAmountChanged;

        private void OnCoinsAmountChanged(long amount) => SetWalletText(amount);

        private void SetWalletText(long amount) =>
            _walletUIText.text = ValueConverter.ConvertValueToString(amount);
    }
}