using UnityEngine;
using UnityEngine.UI;

public class OrderPanel : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _descriptionText;
    [SerializeField] private Text _priceText;
    [SerializeField] private Text _timeText;

    public void SetTextOrder(Order newOrder)
    {
        _nameText.text = newOrder.nameOrder;
        _descriptionText.text = newOrder.description;
        _priceText.text = newOrder.price.ToString();
        _timeText.text = newOrder.time.ToString();
    }

    public void AcceptOrder()
    {
        OrderSystem.instance.AcceptOrder();
    }
}
