using System;
using UnityEngine;
using UnityEngine.UI;

namespace Farm
{

    public class MobileInput : MonoBehaviour, IUseInput
    {
        public event Action<Vector2> OnMove;
        public event Action<bool> OnClick;
        [SerializeField]
        private HarvestButton _harvestButton;
        [SerializeField]
        private MoveControllerImage _moveControllerImage;

        private void Awake()
        {
            _harvestButton.OnClick += (b) => OnClick?.Invoke(b);
            _moveControllerImage.OnChanged += (v) => OnMove?.Invoke(v);
        }
    }
}
