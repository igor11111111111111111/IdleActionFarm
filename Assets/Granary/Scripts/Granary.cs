using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Farm
{
    public class Granary : MonoBehaviour
    {
        public event Action<float> OnSold;
        [SerializeField]
        private GranaryTrigger _trigger;
        [SerializeField]
        private Transform _target;
        public Transform Target => _target;

        private void OnEnable()
        {
            _trigger.OnPlayerEnter += Sale;
        }

        private void OnDisable()
        {
            _trigger.OnPlayerEnter -= Sale;
        }

        private void Sale(PlayerInventory inventory)
        {
            float count = inventory.SellAll();
            OnSold?.Invoke(count);
        }
    }
}
