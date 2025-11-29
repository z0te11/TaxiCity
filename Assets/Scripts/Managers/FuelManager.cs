using System;
using UnityEngine;
public class FuelManager : MonoBehaviour
{
    public static Action<float> OnFuelChanged;
    private float _fuelPLayer;

    public float FuelPlayer
    {
        get { return _fuelPLayer; }
        set
        {
            _fuelPLayer = value;
            if (_fuelPLayer <= 0) _fuelPLayer = 0;
            if (_fuelPLayer > 100) _fuelPLayer = 100;
            OnFuelChanged?.Invoke(_fuelPLayer);
        }
    }
    public void AddFuel(float value)
    {
        FuelPlayer += value;
    }

    public void SpendFuel(float value)
    {
        FuelPlayer -= value;
    }

    public float GetFuelInfo()
    {
        return FuelPlayer;
    }
}
