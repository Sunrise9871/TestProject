using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Buttons
{
    public class CustomButton : Button, IDragHandler
    {
        private bool _isPointerOnButton;

        public event Action OnReleaseClick;
        
        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            _isPointerOnButton = true;
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            _isPointerOnButton = false;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if (_isPointerOnButton)
                OnReleaseClick?.Invoke();
        }

        public void OnDrag(PointerEventData eventData) {}
    }
}