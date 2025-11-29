using System;
using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public static Action<float> OnStaminaChanged;
    private float _staminaPLayer;

    public float StaminaPlayer
    {
        get { return _staminaPLayer; }
        set
        {
            _staminaPLayer = value;
            if (_staminaPLayer <= 0) _staminaPLayer = 0;
            if (_staminaPLayer > 100) _staminaPLayer = 100;
            OnStaminaChanged?.Invoke(_staminaPLayer);
            Debug.Log("Stamina Controller: ChangeStamina");
        }
    }
    public void AddStamina(float value)
    {
        StaminaPlayer += value;
    }

    public void RemoveStamina(float value)
    {
        StaminaPlayer -= value;
    }

    public float GetStaminaInfo()
    {
        return StaminaPlayer;
    }
}
