using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    [SerializeField] private float _tickTimeFuel;
    [SerializeField] private float _fuelСonsumption;
    private float _tickTime;
    private CarMovement _carMove;


    private void Awake()
    {
        _carMove = GetComponent<CarMovement>();
        _tickTime = _tickTimeFuel;
    }

    private void OnEnable()
    {
        FuelController.OnFuelChanged += PlayerHaveFuel;
    }

    private void OnDisable()
    {
        FuelController.OnFuelChanged -= PlayerHaveFuel;
    }

    private void FixedUpdate()
    {
        if (_carMove == null) return;

        if (_tickTime <= 0)
        {
            GameSystem.fuelCtrl.SpendFuel(_carMove.Speed * _fuelСonsumption / 100);
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
