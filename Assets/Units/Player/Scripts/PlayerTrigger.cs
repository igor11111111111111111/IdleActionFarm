using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Farm
{
    public class PlayerTrigger : MonoBehaviour
    {
        [SerializeField]
        private TakerCrops _playerController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CropsPart cropsPart))
            {
                _playerController.TakeCrops(cropsPart);
            }
        }
    }
}
