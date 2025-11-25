using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    [SerializeField] private float _tickTimeFuel;
    [SerializeField] private float _fuelСonsumption;
    [SerializeField] private CarPlayerMovement _carMove;
    private float _tickTime;

    private void Awake()
    {
        _tickTime = _tickTimeFuel;
    }

    private void OnEnable()
    {
        FuelManager.OnFuelChanged += PlayerHaveFuel;
    }

    private void OnDisable()
    {
        FuelManager.OnFuelChanged -= PlayerHaveFuel;
    }

    private void FixedUpdate()
    {
        if (_carMove == null) return;

        if (_tickTime <= 0)
        {
            FuelManager.Instance.SpendFuel(_carMove.Speed * _fuelСonsumption / 100);
            _tickTime = _tickTimeFuel;
        }
        else
        {
            _tickTime -= Time.deltaTime;
        }
    }
    
    private void PlayerHaveFuel(float fuel)
    {
        if (_carMove == null) return;
        if (fuel <= 0) _carMove.CanPlayerMove(false);
        if (fuel > 0) _carMove.CanPlayerMove(true);
    }
}
