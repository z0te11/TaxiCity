using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private float _timePerTick = 2f;
    [SerializeField] private int _spendStForTick = 2;
    private float _currTime;
    private IMovementCar _moveCar;
    private void Start()
    {
        _moveCar = GetComponent<IMovementCar>();
        _currTime = _timePerTick;
    }

    private void FixedUpdate()
    {
        if (_moveCar.Speed > 0)
        {
            if (_currTime <= 0)
            {
                SpendStamina();
                _currTime = _timePerTick;
            }
            else
            {
                _currTime -= Time.fixedDeltaTime;
            }
        }

    }

    private void SpendStamina()
    {
        StaminaManager.Instance.RemoveStamina(_spendStForTick);
    }
}
