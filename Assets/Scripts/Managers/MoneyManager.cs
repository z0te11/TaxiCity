using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static Action<int> OnMoneyChanged;
    public static MoneyManager Instance = null;
    private int _moneyPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

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
