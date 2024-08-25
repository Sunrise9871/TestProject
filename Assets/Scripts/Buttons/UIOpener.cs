using UnityEngine;

namespace Buttons
{
    public class UIOpener : MonoBehaviour
    {
        [SerializeField] private RectTransform _ui;

        private CustomButton _button;

        private void Awake() => _button = GetComponent<CustomButton>();

        private void OnEnable() => _button.OnReleaseClick += OnClick;
        
        private void OnDisable() => _button.OnReleaseClick -= OnClick;
        
        private void OnClick() => _ui.gameObject.SetActive(true);
    }
}
