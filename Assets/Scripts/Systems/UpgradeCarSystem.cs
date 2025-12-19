using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCarSystem : MonoBehaviour
{
    [SerializeField] private PlayerUpgrade _playerUpgrade;
    private List<UpgradeType> _upgradeTypesUsed = new List<UpgradeType>();

    public void UpgradeCarByType(UpgradeType upgrade)
    {
        if (!CheckUsedUpgrade(upgrade)) return;
        
        _playerUpgrade.UpgradeCar(upgrade);
        _upgradeTypesUsed.Add(upgrade);
    }

    public bool CheckUsedUpgrade(UpgradeType upgrade)
    {
        foreach (UpgradeType element in _upgradeTypesUsed)
        {
            if (element == upgrade) return false;
        }
        return true;
    }

}
