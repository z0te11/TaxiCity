using UnityEngine;
using UnityEngine.UI;

public class RegenItem : MonoBehaviour, IItem
{
    [SerializeField] protected ItemType _type;
    [SerializeField] protected float _regen = 30f;
    [SerializeField] protected Text _amountText;
    protected int _amount = 1;
    public ItemType Type
    {
        get
        {
            return _type;
        } 
        set
        {
            _type = value;      
        }
    }
    public int Amount
    {
        get
        {
            return _amount;
        } 
        set
        {
            _amount = value;
            if (_amount < 0) _amount = 0;       
        }
    }

    protected void Start()
    {
        ChangeAmount(_amount);
    }

    public virtual void UseItem()
    {
        if (Amount <= 0) return;
        RemoveFromAmount(1);
        StaminaManager.Instance.AddStamina(_regen);
    }
    public void ChangeAmount(int newAmount)
    {
        Amount = newAmount;
        ChangeText();
    }

    public void RemoveFromAmount(int removeAmount)
    {
        Amount -= removeAmount;
        ChangeText();
    }

    public void AddAmount(int addAmount)
    {
        Amount += addAmount;
        ChangeText();
    }

    public void ChangeText()
    {
        _amountText.text = Amount.ToString();
    }
}
