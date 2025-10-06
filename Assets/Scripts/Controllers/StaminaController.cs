using System;
using UnityEngine;

public class StaminaController
{
    public static Action<int> OnStaminaChanged;
    private int _staminaPLayer;
    public int StaminaPlayer
    {
        get { return _staminaPLayer; }
        set
        {
            _staminaPLayer = value;
            OnStaminaChanged?.Invoke(_staminaPLayer);
            Debug.Log("Stamina Controller: ChangeStamina");
        }
    }
    public void AddStamina(int value)
    {
        StaminaPlayer += value;
    }

    public void RemoveStamina(int value)
    {
        StaminaPlayer -= value;
    }
}
