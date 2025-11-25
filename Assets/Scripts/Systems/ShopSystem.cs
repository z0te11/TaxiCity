using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private ShopPanel _shopPanel;
    public static ShopSystem Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    public void OpenShopRegenPanel()
    {
        _shopPanel.OpenSellRegenPanel();
    }

    public void OpenShopFuelPanel()
    {
        _shopPanel.OpenSellFuelPanel();
    }
}
