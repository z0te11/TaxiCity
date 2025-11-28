using System;
using UnityEngine;
using UnityEngine.UI;

public class CarPanel : MonoBehaviour
{
    [SerializeField] private Text _speedText;
    [SerializeField] private Text _stageText;
    [SerializeField] private Text _staminaText;
    [SerializeField] private Text _moneyText;
    [SerializeField] private Text _fuelText;

    private void OnEnable()
    {
        CarTransmission.OnStageChanged += ShowStageText;
        CarPlayerMovement.OnSpeedChanged += ShowSpeedText;
        StaminaManager.OnStaminaChanged += ShowStaminaText;
        MoneyManager.OnMoneyChanged += ShowMoneyText;
        FuelManager.OnFuelChanged += ShowFuelText;
    }

    private void OnDisable()
    {
        CarTransmission.OnStageChanged -= ShowStageText;
        CarPlayerMovement.OnSpeedChanged -= ShowSpeedText;
        StaminaManager.OnStaminaChanged -= ShowStaminaText;
        MoneyManager.OnMoneyChanged -= ShowMoneyText;
        FuelManager.OnFuelChanged -= ShowFuelText;
    }

    private void ShowSpeedText(float speed)
    {
        _speedText.text = "Speed = " + Mathf.Round(speed).ToString();
    }

    private void ShowStageText(int stage)
    {
        _stageText.text = "Stage = " + stage.ToString();
    }
    private void ShowStaminaText(float stamina)
    {
        _staminaText.text = "Stamina = " + Math.Round(stamina, 2).ToString();
    }

    private void ShowMoneyText(int money)
    {
        _moneyText.text = "Money = " + money.ToString();
    }

    private void ShowFuelText(float fuel)
    {
        _fuelText.text = "Fuel = " + Math.Round(fuel, 2).ToString();
    }
}
