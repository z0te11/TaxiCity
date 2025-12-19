using UnityEngine;
using Zenject;

public class PhonePanelController : MonoBehaviour
{
    [SerializeField] private GameObject _orderPanel;
    [SerializeField] private GameObject _findButton;
    private GameObject _currOrderPanel;
    private OrderSystem _orderSystem;

    [Inject]
    public void Construct(OrderSystem orderSystem)
    {
        _orderSystem = orderSystem;
    }

    private void OnEnable()
    {
        OrderSystem.OnOrderFinished += ClearOrderPanel;
        OrderSystem.OnOrderFinished += ShowFindOrderButton;
        OrderSystem.OnOrderAccepted += HideFindOrderButton;
    }

    private void OnDisable()
    {
        OrderSystem.OnOrderFinished -= ClearOrderPanel;
        OrderSystem.OnOrderFinished -= ShowFindOrderButton;
        OrderSystem.OnOrderAccepted -= HideFindOrderButton;
    }
    public void CreateNewOrderPanel(Order newOrder)
    {
        if (_currOrderPanel != null) Destroy(_currOrderPanel);
        GameObject newOrderPanel = Instantiate(_orderPanel, this.transform.position, Quaternion.identity, this.transform);
        OrderPanel newOrderPanelComp = newOrderPanel.GetComponent<OrderPanel>();
        newOrderPanelComp.Initialize(_orderSystem);
        newOrderPanelComp.SetTextOrder(newOrder);
        _currOrderPanel = newOrderPanel;
    }


    private void ShowFindOrderButton()
    {
        _findButton.SetActive(true);
    }

    private void HideFindOrderButton()
    {
        _findButton.SetActive(false);
    }

    private void ClearOrderPanel()
    {
        if (_currOrderPanel == null) return;
        Destroy(_currOrderPanel);
    }
}
