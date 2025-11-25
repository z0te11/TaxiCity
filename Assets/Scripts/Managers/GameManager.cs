using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private FuelManager _fuelManager;
    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private StaminaManager _staminaManager;

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
