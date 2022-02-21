using System.Collections.Generic;
using UnityEngine;

namespace Farm
{
    public class GranaryCoinsHandler : MonoBehaviour
    {
        [SerializeField]
        private Coin _coinPrefab;
        [SerializeField]
        private UIMoney _uIMoney;
        [SerializeField]
        private Transform _coinParent;
        [SerializeField]
        private Camera _camera;
        private List<Coin> _coins;
        private float _speed;
        private PlayerData _playerData;
        private InventoryGranaryHandler _inventoryGranaryHandler;

        public void Init(PlayerData playerData, InventoryGranaryHandler inventoryGranaryHandler)
        {
            _coins = new List<Coin>();
            _speed = 0.04f;
            _playerData = playerData;
            _inventoryGranaryHandler = inventoryGranaryHandler;
            _inventoryGranaryHandler.OnCropGranaryEnter += OnCropEnterHandler;
        }

        private void OnCropEnterHandler(Vector3 position)
        {
            Coin coin = Instantiate(_coinPrefab, _coinParent);
            SetPosition(coin);
            _coins.Add(coin);
        }

        private void Update()
        {
            for (int i = 0; i < _coins.Count; i++)
            {
                Move(_coins[i]);
                ValidateTarget(_coins[i]);
            }
        }

        private void SetPosition(Coin coin)
        {
            var rect = coin.GetComponent<RectTransform>();
            var screenPos = RectTransformUtility.WorldToScreenPoint(_camera, _inventoryGranaryHandler.GranaryPosition);

            Vector2 localPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPos, _camera, out localPos);

            rect.anchoredPosition = localPos;
        }

        private void Move(Coin coin)
        {
            coin.transform.position = Vector3.MoveTowards(coin.transform.position, _uIMoney.transform.position, _speed);
        }

        private void ValidateTarget(Coin coin)
        {
            if (coin.transform.position == _uIMoney.transform.position)
            {
                _coins.Remove(coin);
                Destroy(coin.gameObject);
                _playerData.Money += _playerData.CropPrice;
            }
        }
    }
}
 