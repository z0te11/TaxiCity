using UnityEngine;

public class ShopPoint : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        ShopSystem.Instance.OpenShopRegenPanel();
    }
}
