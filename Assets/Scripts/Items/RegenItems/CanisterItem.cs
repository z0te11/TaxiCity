using UnityEngine;
using UnityEngine.UI;

public class CanisterItem : RegenItem
{
    public override void UseItem()
    {
        if (Amount <= 0) return;
        RemoveFromAmount(1);
        FuelManager.Instance.AddFuel(_regen);
    }
}
