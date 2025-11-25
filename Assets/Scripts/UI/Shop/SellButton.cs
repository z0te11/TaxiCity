using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour, ISell
{
    [SerializeField] private ItemType _type;
    [SerializeField] private int _price = 10;
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

    public void BuyItem()
    {
        if (!MoneyManager.Instance.CheckMoney(_price)) return;

        InventarSystem.Instance.AddItemByType(Type, 1);
        MoneyManager.Instance.SpendMoney(Price);
    }
}
