using UnityEngine;

namespace Farm
{
    public class PlayerInventory : MonoBehaviour
    {
        public InventoryVisualization Visual => _visual;
        [SerializeField]
        private InventoryVisualization _visual;
        [SerializeField]
        private int _maxValue;
        [SerializeField]
        private UIInventory _uIInventory;
        private PlayerController _controller;
        private int _currentValue;
        private float _normalizedValue => _currentValue / (float)_maxValue;

        private void Awake()
        {
            _currentValue = 0;
            _controller = GetComponent<PlayerController>();
        }

        private void OnEnable()
        {
            _controller.OnTakeCrops += TryTakeHandler;
        }

        private void OnDisable()
        {
            _controller.OnTakeCrops -= TryTakeHandler;
        }

        public int SellAll()
        {
            var value = _currentValue;
            _currentValue = 0;
            _uIInventory.Refresh(_normalizedValue);
            return value;
        }

        private void TryTakeHandler(CropsPart cropsPart)
        {
            if(_currentValue < _maxValue && cropsPart.IsCanLifted)
            {
                _currentValue++;
                _uIInventory.Refresh(_normalizedValue);
                Destroy(cropsPart.GetComponent<Collider>());
                _visual.Show(cropsPart);
            }
        }
    }
}
