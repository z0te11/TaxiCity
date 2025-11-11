using UnityEngine;

public class FuelPoint : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        GameSystem.fuelCtrl.AddFuel(50);
    }
}
