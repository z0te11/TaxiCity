public interface IUpgradeItem
{
    public UpgradeType Type {get;}
    public int Price {get;}

    public void Upgrade();
}
