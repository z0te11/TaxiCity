using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static Action<int> OnMoneyChanged;
    private int _moneyPlayer;

    public int MoneyPlayer
    {
        get { return _moneyPlayer; }
        set
        {
            _moneyPlayer = value;
            if (_moneyPlayer < 0) _moneyPlayer = 0;
            OnMoneyChanged?.Invoke(_moneyPlayer);
        }
    }

    public void AddMoney(int money)
    {
        MoneyPlayer += money;
    }

    public void SpendMoney(int money)
    {
        MoneyPlayer -= money;
    }

    public bool CheckMoney(int money)
    {
        if (money > MoneyPlayer) return false;
        return true;
    }
}
