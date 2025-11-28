using System.Collections;
using System;
using UnityEngine;

public class CarTransmission : MonoBehaviour, ITransmission
{
    public static Action<int> OnStageChanged;
    [SerializeField] public bool _isAuto = false;
    private int _stage = 1;
    private int _maxStage = 5;

    private void OnEnable()
    {
        CarPlayerMovement.OnSpeedChanged += ChangeStage;
    }

    private void OnDisable()
    {
        CarPlayerMovement.OnSpeedChanged -= ChangeStage;
    }
    public int Stage
    {
        get { return _stage; }
        set
        {
            if (value <= _maxStage && value > 0) _stage = value;
            OnStageChanged?.Invoke(_stage);
        }
    }

    public void NextStage()
    {
        Stage++;
    }
    public void PreviousStage()
    {
        Stage--;
    }

    private void ChangeStage(float speed)
    {
        if (!_isAuto) return;

        Stage = Utils.CalculateNewStage(speed);
    }
}
