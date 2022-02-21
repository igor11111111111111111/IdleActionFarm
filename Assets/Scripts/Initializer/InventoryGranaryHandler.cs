
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Farm
{

    public class InventoryGranaryHandler : MonoBehaviour
    {
        public event Action<Vector3> OnCropGranaryEnter;
        public Vector3 GranaryPosition => _granary.transform.position;
        private Granary _granary;
        private InventoryVisualization _inventoryVisual;
        private List<CropsPart> _crops;
        private float _speed = 0.2f;

        public void Init(Granary granary, PlayerInventory inventory, InventoryVisualization inventoryVisual)
        { 
            _granary = granary;
            _inventoryVisual = inventoryVisual;

            granary.OnSold += (count) =>
            { 
                StopAllCoroutines();
                StartCoroutine(CustomUpdate());
            };
        }

        private IEnumerator CustomUpdate()
        {
            _crops = _inventoryVisual.AllCrops;
            _inventoryVisual.GranaryTrading(true);

            while (true)
            {
                for (int i = 0; i < _crops.Count; i++)
                {
                    if (_crops[i] != null)
                    {
                        SetSettings(_crops[i]);
                        float speed = UnityEngine.Random.Range(_speed - 0.1f, _speed + 0.1f);
                        Move(_crops[i], speed);
                        ValidateTarget(_crops[i]);
                    }
                }

                if (_crops.Count == 0)
                {
                    _inventoryVisual.GranaryTrading(false);
                    yield break;
                }

                yield return new WaitForSeconds(0.1f);
            }
        }

        private void SetSettings(CropsPart crop)
        {
            if (crop.transform.parent != null)
            {
                crop.transform.parent = null;
                crop.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            }
        }
    
        private void Move(CropsPart crop, float speed)
        {
            crop.transform.position = Vector3.MoveTowards(crop.transform.position, _granary.Target.position, speed);
        }

        private void ValidateTarget(CropsPart crop)
        {
            if (crop.transform.position == _granary.Target.position)
            {
                _inventoryVisual.RemoveCropsPart(crop);
                _crops.Remove(crop);
                OnCropGranaryEnter?.Invoke(_granary.transform.position);
            }
        }
    }
}
