using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Farm
{
    public class GranaryTrigger : MonoBehaviour
    {
        public event Action<PlayerInventory> OnPlayerEnter;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerInventory inventory))
            {
                OnPlayerEnter?.Invoke(inventory);
            }
        }
    }
}
