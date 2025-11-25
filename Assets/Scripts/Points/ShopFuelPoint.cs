using UnityEngine;

public class ShopFuelPoint : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        ShopSystem.Instance.OpenShopFuelPanel();
    }
}
