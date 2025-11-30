using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private FuelManager _fuelManager;
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private StaminaManager _staminaManager;
    [SerializeField] private InventorySystem _inventorySystem;
    [SerializeField] private WaySystem _waySystem;
    [SerializeField] private OrderSystem _orderSystem;
    [SerializeField] private ShopSystem _shopSystem;
    [SerializeField] private BuildingSystem _buildingSystem;
    [SerializeField] private TimeSystem _timeSystem;


    public override void InstallBindings()
    {
        Container.Bind<PlayerData>().FromInstance(_playerData).AsSingle();
        Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
        Container.Bind<FuelManager>().FromInstance(_fuelManager).AsSingle();
        Container.Bind<MoneyManager>().FromInstance(_moneyManager).AsSingle();
        Container.Bind<StaminaManager>().FromInstance(_staminaManager).AsSingle();
        Container.Bind<InventorySystem>().FromInstance(_inventorySystem).AsSingle();
        Container.Bind<WaySystem>().FromInstance(_waySystem).AsSingle();
        Container.Bind<OrderSystem>().FromInstance(_orderSystem).AsSingle();
        Container.Bind<ShopSystem>().FromInstance(_shopSystem).AsSingle();
        Container.Bind<BuildingSystem>().FromInstance(_buildingSystem).AsSingle();
        Container.Bind<TimeSystem>().FromInstance(_timeSystem).AsSingle();
    }
}
