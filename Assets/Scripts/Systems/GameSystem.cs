using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static StaminaController staminaCtrl;
    public static MoneyController moneyCtrl;

    private void Awake()
    {
        InitializeControllers();
    }

    private void Start()
    {
        StartGame();
        Debug.Log("GameSystem: StartGame");
    }

    private void StartGame()
    {
        if (staminaCtrl != null) staminaCtrl.StaminaPlayer = 100;
        if (moneyCtrl != null) moneyCtrl.MoneyPlayer = 10;
    }

    private void InitializeControllers()
    {
        staminaCtrl = new StaminaController();
        moneyCtrl = new MoneyController();
    }

}
