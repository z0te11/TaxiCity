using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private PlayerData _playerData;
    private FuelManager _fuelManager;
    private MoneyManager _moneyManager;
    private StaminaManager _staminaManager;

    [Inject]
    public void Construct(PlayerData playerData, FuelManager fuelManager, MoneyManager moneyManager, StaminaManager staminaManager)
    {
        _playerData = playerData;
        _fuelManager = fuelManager;
        _moneyManager = moneyManager;
        _staminaManager = staminaManager;
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        _fuelManager.AddFuel(_playerData.fuelPlayer);
        _moneyManager.AddMoney(_playerData.moneyPlayer);
        _staminaManager.AddStamina(_playerData.staminaPlayer);
    }
}
