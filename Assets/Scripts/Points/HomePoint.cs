using UnityEngine;

public class HomePoint : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        GameSystem.staminaCtrl.AddStamina(50);
    }
}
