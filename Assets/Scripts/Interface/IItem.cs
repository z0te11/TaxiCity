
public interface IItem
{
    public ItemType Type { get;}
    public int Amount { get; set;}
    public void UseItem();

    public void ChangeAmount(int newAmount);

    public void RemoveFromAmount(int removeAmount);

    public void AddAmount(int addAmount);
}
