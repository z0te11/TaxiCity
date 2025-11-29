using UnityEngine;

public class SellButton : MonoBehaviour, ISell
{
    [SerializeField] private ItemType _type;
    [SerializeField] private int _price = 10;
    private MoneyManager _moneyManager;
    private InventorySystem _inventorySystem;
    public ItemType Type
    {
        get
        {
            return _type;
        }
    }

    public int Price
    {
        get
        {
            return _price;
        }
        set
        {
            _price = value;
        }
    }

    public void Initialize(MoneyManager moneyManager, InventorySystem inventorySystem)
    {
        _moneyManager = moneyManager;
        _inventorySystem = inventorySystem;
        Debug.Log("Inhect " + this);
    }

    public void BuyItem()
    {
        if (!_moneyManager.CheckMoney(_price)) return;

        _inventorySystem.AddItemByType(Type, 1);
        _moneyManager.SpendMoney(Price);
    }
}
