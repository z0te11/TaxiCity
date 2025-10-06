using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static StaminaController staminaSystem;
    private void Awake()
    {
        InitializeSystems();
    }

    private void Start()
    {
        StartGame();
        Debug.Log("GameSystem: StartGame");
    }

    private void StartGame()
    {
        if (staminaSystem != null) staminaSystem.StaminaPlayer = 100;
    }

    private void InitializeSystems()
    {
        staminaSystem = new StaminaController();
    }

}
