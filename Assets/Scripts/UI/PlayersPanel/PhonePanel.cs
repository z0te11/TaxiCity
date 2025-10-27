using UnityEngine;

public class PhonePanel : MonoBehaviour
{
    [SerializeField] private GameObject _orderPanel;
    private GameObject _currOrderPanel;

    public void CreateNewOrderPanel(Order newOrder)
    {
        if (_currOrderPanel != null) Destroy(_currOrderPanel);
        var newOrderPanel = Instantiate(_orderPanel, this.transform.position, Quaternion.identity, this.transform);
        newOrderPanel.GetComponent<OrderPanel>().SetTextOrder(newOrder);
        _currOrderPanel = newOrderPanel;
    }
}
