using UnityEngine;
using UnityEngine.UI;

public class CoffeeItem : RegenItem
{
    public override void UseItem()
    {
        if (Amount <= 0) return;
        RemoveFromAmount(1);
        StaminaManager.Instance.AddStamina(_regen);
    }
}
