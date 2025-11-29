using UnityEngine;

public class SellPanel : MonoBehaviour
{
    [SerializeField] private SellButton[] _sellButtons;

    private MoneyManager _moneyManger;
    private InventorySystem _inventorySystem;

    public void Initialize(MoneyManager moneyManager, InventorySystem inventorySystem)
    {
        _moneyManger = moneyManager;
        _inventorySystem = inventorySystem;
        Debug.Log("Inhect " + this);
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        for (int i = 0; i < _sellButtons.Length; i++)
        {
            _sellButtons[i].Initialize(_moneyManger, _inventorySystem);
        }
    }

    public void ClosePanel()
    {
        Destroy(gameObject);
    }
}
