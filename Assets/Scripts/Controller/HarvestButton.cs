using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Farm
{
    public class HarvestButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action<bool> OnClick;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnClick?.Invoke(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnClick?.Invoke(false);
        }
    }
}
