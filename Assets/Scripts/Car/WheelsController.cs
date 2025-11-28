using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsController : MonoBehaviour
{
    [SerializeField] private GameObject[] _frontWheels;
    [SerializeField] private GameObject[] _backWheels;
    [SerializeField] private float _maxWheelTurnAngle = 30f;
    [SerializeField] private float _wheelRotationSpeed = 180f;
    private float _currentTurnAngle = 0f;

    public void RotationForward(float speed)
    {
        float rotationAmount = speed * _wheelRotationSpeed * Time.deltaTime;

        foreach (var wheel in _frontWheels)
        {
            if (wheel != null)
                wheel.transform.Rotate(rotationAmount, 0, 0);
        }
        
        foreach (var wheel in _backWheels)
        {
            if (wheel != null)
                wheel.transform.Rotate(rotationAmount, 0, 0);
        }
    }

    public void RotationTurn(float turnInput)
    {
        float targetTurnAngle = turnInput * _maxWheelTurnAngle;
        
        _currentTurnAngle = Mathf.Lerp(_currentTurnAngle, targetTurnAngle, 8f * Time.deltaTime);

        foreach (var wheel in _frontWheels)
        {
            if (wheel != null)
            {
                Vector3 currentRotation = wheel.transform.localEulerAngles;
                wheel.transform.localEulerAngles = new Vector3(
                    currentRotation.x, 
                    _currentTurnAngle, 
                    currentRotation.z
                );
            }
        }
    }
}
