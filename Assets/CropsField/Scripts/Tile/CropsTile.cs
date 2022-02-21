using System;
using UnityEngine;

namespace Farm
{
    public class CropsTile : MonoBehaviour
    {
        public CropsGrowth CropsGrowth => _cropsGrowth;
        private CropsGrowth _cropsGrowth;
        [SerializeField]
        private CropFilling _fillingPrefab;
        private GameObject _slisedPart;

        public void Init(CropsGrowth cropsGrowth)
        {
            _cropsGrowth = cropsGrowth;
            _cropsGrowth.OnGrowComplete += () =>
            {
                var filling = CreateFilling();
                _cropsGrowth.InitFilling(filling);
            };
        }

        public void InitSlisedPart(GameObject slisedPart)
        {
            _slisedPart = slisedPart;
        }

        public CropFilling CreateFilling()
        {
            Destroy(_slisedPart);

            var filling = Instantiate(_fillingPrefab, transform);
            filling.Init(this);

            return filling;
        }
    }
}
