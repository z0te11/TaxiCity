using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private ShopPanel _shopPanel;
    public void OpenShopRegenPanel()
    {
        _shopPanel.OpenSellRegenPanel();
    }

    public void OpenShopFuelPanel()
    {
        _shopPanel.OpenSellFuelPanel();
    }
}
