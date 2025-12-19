using UnityEngine;
using Zenject;

public class HomePoint : MonoBehaviour
{
    private StaminaManager _staminaManager;

    [Inject]
    public void Construct(StaminaManager staminaManager)
    {
        _staminaManager = staminaManager;
    }
    public void OnTriggerEnter(Collider other)
    {
        _staminaManager.AddStamina(50);
    }
}
