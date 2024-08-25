using DG.Tweening;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public class WindowPopUpEffect : MonoBehaviour
    {
        [SerializeField] private Vector3 _startScale = new(0.8f, 0.8f, 1f);
        [SerializeField] private float _animationDuration = 0.2f;
        
        private RectTransform _window;
        
        private void Awake() => _window = GetComponent<RectTransform>();

        private void OnEnable()
        {
            _window.localScale = _startScale;
            _window.DOScale(Vector3.one, _animationDuration);
        } 
    }
}