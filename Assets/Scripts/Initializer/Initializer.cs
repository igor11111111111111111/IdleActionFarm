using UnityEngine;

namespace Farm
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField]
        private CropsSpawner _cropsSpawner;
        [SerializeField]
        private GrowthTickUpdate _growthTickUpdate;
        [SerializeField]
        private MobileInput _mobileInput;
        [SerializeField]
        private PlayerController _playerController;
        [SerializeField]
        private PlayerInventory _playerInventory;
        [SerializeField]
        private PlayerData playerData;
        [SerializeField]
        private InventoryVisualization _inventoryVisual;
        [SerializeField]
        private Granary _granary;
        [SerializeField]
        private InventoryGranaryHandler _inventoryGranaryHandler;
        [SerializeField]
        private GranaryCoinsHandler _granaryCoinsHandler;
        [SerializeField]
        private UIMoney _uIMoney;

        private void Start()
        {
            _cropsSpawner.Init();
            _growthTickUpdate.Init(_cropsSpawner.SpawnedTiles);

            _playerController.Init(_mobileInput);

            _inventoryGranaryHandler.Init(_granary, _playerInventory, _inventoryVisual);

            _granaryCoinsHandler.Init(playerData, _inventoryGranaryHandler);

            PlayerDataUIMoneyHandler playerDataUIMoneyHandler = new PlayerDataUIMoneyHandler();
            playerDataUIMoneyHandler.Init(playerData, _uIMoney);
        }
    }
}
