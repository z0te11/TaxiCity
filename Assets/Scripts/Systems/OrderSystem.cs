using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    [SerializeField] private Order[] _orders;
    [SerializeField] private PhonePanel _phonePanel;
    public Order currnetOrder;
    private Order _foundOrder;
    public static OrderSystem instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void FindNewOrder()
    {
        _foundOrder = _orders[Random.Range(0, 2)];
        _phonePanel.CreateNewOrderPanel(_foundOrder);
    }

    public void AcceptOrder()
    {
        currnetOrder = _foundOrder;
        if (currnetOrder != null) WaySystem.instance.CreateWayRoad(currnetOrder.orderWay);
    }
}


