using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputCar : MonoBehaviour
{
    private IMovementCar _moveCar;
    private ITransmission _transCar;

    private void Awake()
    {
        _moveCar = GetComponent<IMovementCar>();
        _transCar = GetComponent<ITransmission>();
    }

    private void Update()
    {
        if (_transCar != null)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                _transCar.NextStage();
            }
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                _transCar.PreviousStage();
            }
        }
    }

    private void FixedUpdate()
    {
        if (_moveCar != null)
        {
            _moveCar.Move(UserInputSystem.moveInput);
        } 
    }
}
