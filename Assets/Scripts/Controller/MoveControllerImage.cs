using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Farm
{
    public class MoveControllerImage : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        public event Action<Vector2> OnChanged;
        [SerializeField]
        private RectTransform _rectTransform;
        [SerializeField]
        private GameObject _image;
        private float _size => _rectTransform.sizeDelta.x;
        private Vector2 _startPosition;
        private Vector2 _normalizedPosition;

        private void Awake()
        {
            _startPosition = _rectTransform.anchoredPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var position = new Vector2(
                _rectTransform.anchoredPosition.x + eventData.delta.x,
                _rectTransform.anchoredPosition.y + eventData.delta.y);

            position = new Vector2(
                Mathf.Clamp(position.x, _startPosition.x - _size, _startPosition.x + _size),
                Mathf.Clamp(position.y, _startPosition.y - _size, _startPosition.y + _size));

            _normalizedPosition = position / _size;
            _normalizedPosition.Normalize();
            
            _rectTransform.anchoredPosition = position;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition = _startPosition;
            _normalizedPosition = Vector2.zero;
        }

        private void Update()
        {
            OnChanged?.Invoke(_normalizedPosition);
        }
    }
}
