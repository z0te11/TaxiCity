using UnityEngine;
using Zenject;

public class FuelPoint : MonoBehaviour
{
    private FuelManager _fuelManager;
    
    [Inject]
    private void Construct(FuelManager fuelManager)
    {
        _fuelManager = fuelManager;
    }
    public void OnTriggerEnter(Collider other)
    {
        _fuelManager.AddFuel(50);
    }
}
