using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] private CarPlayerMovement _carMove;
    [SerializeField] private PlayerFuel _carFuel;

    public void UpgradeCar(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.FuelTank:
                {
                    break;
                }
            case UpgradeType.Motor:
                {
                    break;
                }
            case UpgradeType.Transmission:
                {
                    break;
                }
            case UpgradeType.Wheels:
                {
                    break;
                }
        }
    }
}
