using System;
using UnityEngine;
using UnityEngine.UI;

public class CarPanel : MonoBehaviour
{
    [SerializeField] private Text _speedText;
    [SerializeField] private Text _stageText;
    [SerializeField] private Text _staminaText;
    private void OnEnable()
    {
        CarMovement.OnStageChanged += ShowStageText;
        CarMovement.OnSpeedChanged += ShowSpeedText;
        StaminaController.OnStaminaChanged += ShowStaminaText;
    }

    private void OnDisable()
    {
        CarMovement.OnStageChanged -= ShowStageText;
        CarMovement.OnSpeedChanged -= ShowSpeedText;
        StaminaController.OnStaminaChanged -= ShowStaminaText;
    }

    private void ShowSpeedText(float speed)
    {
        _speedText.text = "Speed = " + Mathf.Round(speed).ToString();
    }

    private void ShowStageText(int stage)
    {
        _stageText.text = "Stage = " + stage.ToString();
    }
    private void ShowStaminaText(int stamina)
    {
        _staminaText.text = "Stamina = " + stamina.ToString();
    }
}
