using UnityEngine;
using Zenject;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject _sellRegenPanel;
    [SerializeField] private GameObject _sellFuelPanel;
    private GameObject _currentPanel = null;
    private MoneyManager _moneyManager;
    private InventorySystem _inventorySystem;

    [Inject]
    public void Construct(MoneyManager moneyManager, InventorySystem inventorySystem)
    {
        _moneyManager = moneyManager;
        _inventorySystem = inventorySystem;
        Debug.Log("Inhect " + this);
    }

    private void InitializeSellPanel(GameObject sellPanel)
    {
        if (!sellPanel.GetComponent<SellPanel>()) return;
        if (_currentPanel != null) Destroy(_currentPanel);

        GameObject newSellPanel = Instantiate(sellPanel, this.transform.position, Quaternion.identity, this.transform);
        SellPanel newSellPanelComp = newSellPanel.GetComponent<SellPanel>();
        newSellPanelComp.Initialize(_moneyManager, _inventorySystem);
        _currentPanel = newSellPanel;
    }

    public void OpenSellRegenPanel()
    {
        InitializeSellPanel(_sellRegenPanel);
    }

    public void OpenSellFuelPanel()
    {
        InitializeSellPanel(_sellFuelPanel);
    }
}
