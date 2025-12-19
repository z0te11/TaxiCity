using UnityEngine;
using Zenject;

public class ShopFuelPoint : MonoBehaviour
{
    private ShopSystem _shopSystem;

    [Inject]
    public void Construct(ShopSystem shopSystem)
    {
        _shopSystem = shopSystem;
    }
    public void OnTriggerEnter(Collider other)
    {
        _shopSystem.OpenShopFuelPanel();
    }
}
