using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Farm
{
    public class InventoryVisualization : MonoBehaviour
    {
        [SerializeField]
        private Transform _body;
        public List<CropsPart> AllCrops => _cropsLimit.Union(_cropsForMove).ToList();
        private List<CropsPart> _cropsLimit;
        private List<CropsPart> _cropsForMove;
        private float _speed;
        private Vector3 _cropSize;
        private bool _granaryTrading;

        private void Awake()
        {
            _speed = 0.2f;
            _granaryTrading = false;
            _cropSize = new Vector3(0.6f, 0.04f, 0.6f);
            _cropsForMove = new List<CropsPart>();
            _cropsLimit = new List<CropsPart>();
        }

        public void Show(CropsPart cropsPart)
        {
            cropsPart.transform.parent = transform;

            var rotation = cropsPart.transform.localRotation.eulerAngles;
            cropsPart.transform.localRotation = Quaternion.Euler(0, rotation.y, 0);

            if (!_cropsForMove.Contains(cropsPart))
            {
                _cropsForMove.Add(cropsPart);
            }
        }

        public void GranaryTrading(bool active)
        {
            _granaryTrading = active;
        }

        public void RemoveCropsPart(CropsPart cropsPart)
        {
            _cropsForMove.Remove(cropsPart);
            _cropsLimit.Remove(cropsPart);
            Destroy(cropsPart.gameObject);
        }

        private void Update()
        {
            if (_cropsForMove.Count == 0 || _granaryTrading)
                return;

            for (int i = 0; i < _cropsForMove.Count; i++)
            {
                if (_cropsForMove[i] == null)
                    return;

                var cropTransform = _cropsForMove[i].transform;

                Vector3 target = _body.localPosition +
                    new Vector3(0, GetEmptyIndex() * (_cropSize.y / 2), 0);

                cropTransform.localPosition = Vector3.MoveTowards(cropTransform.localPosition, target, _speed);

                if (cropTransform.localPosition != target)
                    return;

                _cropsLimit.Add(_cropsForMove[i]);
                _cropsForMove.Remove(_cropsForMove[i]);
                cropTransform.localScale = _cropSize;
            }
        }

        private int GetEmptyIndex() //linq need
        {
            for (int i = 0; i < _cropsLimit.Count; i++)
            {
                if (_cropsLimit[i] == null)
                    return i;
            }

            return -1; //!!!
        }
    }
}
