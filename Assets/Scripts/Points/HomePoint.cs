using UnityEngine;

public class HomePoint : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        StaminaManager.Instance.AddStamina(50);
    }
}
