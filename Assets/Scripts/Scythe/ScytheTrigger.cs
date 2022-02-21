using System;
using UnityEngine;

namespace Farm
{
    [RequireComponent(typeof(Collider))]
     
    public class ScytheTrigger : MonoBehaviour
    {
        public event Action<CropFilling> OnFindTile;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out CropFilling cropsTileTrigger))
            {
                OnFindTile?.Invoke(cropsTileTrigger);
            }
        }
    }
}
