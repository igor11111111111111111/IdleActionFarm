using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Farm
{
    public class PlayerData : MonoBehaviour
    {
        public event Action<float> OnMoneyChanged;

        [SerializeField]
        private float _cropPrice;
        public float CropPrice => _cropPrice;

        public float Speed => _speed;
        private float _speed;

        public float Money
        {
            get
            {
                return _money;
            }

            set
            {
                if (_money == value)
                    return;

                _money = value;
                OnMoneyChanged?.Invoke(value);
            }
        }

        private float _money;

        private void Awake()
        {
            Money = 0;
            _speed = 2f;
        }
    }
}
