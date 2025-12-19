using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private InventarPanel _inventarPanel;
    [SerializeField] private IItem[] _iItems;

    private void Awake()
    {
        _iItems = _inventarPanel.GetComponentsInChildren<IItem>();
    }

    public IItem FindItemByType(ItemType itemType)
    {
        foreach (IItem element in _iItems)
        {
            if (itemType == element.Type)
            {
                return element;
            }
        }
        return null;
    }

    public void UseItemByType(ItemType itemType)
    {
        FindItemByType(itemType).UseItem();
    }

    public void UseItem(IItem item)
    {
        item.UseItem();
    }

    public void RemoveItemByType(ItemType itemType, int amount)
    {
        FindItemByType(itemType).RemoveFromAmount(amount);
    }

    public void RemoveItem(IItem item, int amount)
    {
        item.RemoveFromAmount(amount);
    }

    public void AddItemByType(ItemType itemType, int amount)
    {
        FindItemByType(itemType).AddAmount(amount);
    }

    public void AddItem(IItem item, int amount)
    {
        item.AddAmount(amount);
    }
}


