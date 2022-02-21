using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Farm
{ 
    public class CropFilling : MonoBehaviour
    {
        [SerializeField]
        private Material _material;
        public Material Material => _material;
        public CropsTile CropsTile => _cropsTile;
        private CropsTile _cropsTile;
        public Transform Parent => _parent;
        private Transform _parent;

        public void Init(CropsTile cropsTile)
        {
            _cropsTile = cropsTile;
            _parent = cropsTile.transform;
        }
    }
}
