using UnityEngine;
using Zenject;

public class PlayerFuel : MonoBehaviour
{
    [SerializeField] private float _tickTimeFuel;
    [SerializeField] private float _fuelСonsumption;
    [SerializeField] private CarPlayerMovement _carMove;

    private FuelManager _fuelManager;
    private float _tickTime;
    
    [Inject]
    private void Construct(FuelManager fuelManager)
    {
        _fuelManager = fuelManager;
    }
    

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
            _fuelManager.SpendFuel(_carMove.Speed * _fuelСonsumption / 100);
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
