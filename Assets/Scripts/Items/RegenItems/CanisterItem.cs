using Zenject;

public class CanisterItem : RegenItem
{
    private FuelManager _fuelManager;
    
    [Inject]
    private void Construct(FuelManager fuelManager)
    {
        _fuelManager = fuelManager;
    }
    public override void UseItem()
    {
        if (Amount <= 0) return;
        RemoveFromAmount(1);
        _fuelManager.AddFuel(_regen);
    }
}
