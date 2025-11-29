using Zenject;

public class CoffeeItem : RegenItem
{
    private StaminaManager _staminaManager;

    [Inject]
    public void Construct(StaminaManager staminaManager)
    {
        _staminaManager = staminaManager;
    }
    public override void UseItem()
    {
        if (Amount <= 0) return;
        RemoveFromAmount(1);
        _staminaManager.AddStamina(_regen);
    }
}
