using UnityEngine;

public class FuelPoint : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        FuelManager.Instance.AddFuel(50);
    }
}
