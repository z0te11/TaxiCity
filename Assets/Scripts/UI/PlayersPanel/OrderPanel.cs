using UnityEngine;
using UnityEngine.UI;

public class OrderPanel : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _descriptionText;
    [SerializeField] private Text _priceText;
    [SerializeField] private Text _timeText;
    [SerializeField] private Text _startOrderText;
    [SerializeField] private Text _finishOrderText;
    

    public void SetTextOrder(Order newOrder)
    {
        _nameText.text = newOrder.nameOrder;
        _descriptionText.text = newOrder.description;
        _priceText.text = newOrder.price.ToString();
        _timeText.text = newOrder.time.ToString();
        _startOrderText.text = newOrder.orderWay[0].ToString() + " street";
        if (newOrder.orderWay.Count > 1)
        {
            _finishOrderText.text = "";
            for (int i = 1; i < newOrder.orderWay.Count; i++)
            {
                _finishOrderText.text += newOrder.orderWay[i].ToString() + " street.";
            }
                
        }
        else
        {
            _finishOrderText.text = "no finish street";
        }
    }

    public void AcceptOrder()
    {
        OrderSystem.instance.AcceptOrder();
    }
}
