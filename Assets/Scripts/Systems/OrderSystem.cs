using UnityEngine;
using System;
using Zenject;

public class OrderSystem : MonoBehaviour
{
    public static Action OnOrderFinished;
    public static Action OnOrderAccepted;
    [SerializeField] private Order[] _orders;
    [SerializeField] private PhonePanelController _phonePanel;
    public Order currnetOrder;
    private Order _foundOrder;
    private MoneyManager _moneyManager;
    private WaySystem _waySystem;

    [Inject]
    public void Construct(MoneyManager moneyManager, WaySystem waySystem)
    {
        _moneyManager = moneyManager;
        _waySystem = waySystem;
    }

    public void FindNewOrder()
    {
        _foundOrder = _orders[UnityEngine.Random.Range(0, 2)];
        _phonePanel.CreateNewOrderPanel(_foundOrder);
    }

    public void AcceptOrder()
    {
        currnetOrder = _foundOrder;
        if (currnetOrder != null) _waySystem.CreateWayRoad(currnetOrder.orderWay);
        OnOrderAccepted?.Invoke();
    }

    public void FinishOrder()
    {
        _moneyManager.AddMoney(currnetOrder.price);
        OnOrderFinished?.Invoke();
        currnetOrder = null;
    }

    public void FailOrder()
    {
        OnOrderFinished?.Invoke();
        currnetOrder = null;
    }
}


