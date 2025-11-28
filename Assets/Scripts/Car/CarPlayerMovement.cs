using System;
using UnityEngine;

public class CarPlayerMovement : MonoBehaviour, IMovementCar
{
    public static Action<float> OnSpeedChanged;
    
    [Header("Movement Settings")]
    [SerializeField] private float _maxSpeed = 50f;
    [SerializeField] private float _backMaxSpeed = 10f;
    [SerializeField] private float _acceleration = 1f;
    [SerializeField] private float _deceleration = 1f;
    [SerializeField] private float _rotationSpeed = 8f;
    [SerializeField] private WheelsController _wheelsCtr;

    private Rigidbody _rb;
    private float _maxRotationSpeed;
    private float _currentSpeed;
    private bool _canMove = true;
    private ITransmission _iTransmission;

    public float Speed
    {
        get { return _currentSpeed; }
        set
        {
            if (value < _maxSpeed) _currentSpeed = value;
            OnSpeedChanged?.Invoke(_currentSpeed*3.6f);
        }
    }
    public float RotationSpeed
    {
        get { return _rotationSpeed; }
        set { if (value < _maxRotationSpeed) _rotationSpeed = value; }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _iTransmission = GetComponent<ITransmission>();
    }

    private void Start()
    {
        _maxRotationSpeed = RotationSpeed;
    }

    public void CanPlayerMove(bool isCan)
    {
        _canMove = isCan;
    }

    public void Move(Vector2 pos)
    {
        MoveForward(pos.y);
        TurnSide(pos.x);
    }

    public void MoveForward(float verticalInput)
    {
        if (verticalInput > 0 && _canMove)
        {
            var newAccel = Utils.CalculateAcceleration(_iTransmission.Stage, _acceleration, Speed);
            Speed = Mathf.Lerp(Speed, _maxSpeed, newAccel * Time.fixedDeltaTime);
        }
        else if (verticalInput < 0 && _canMove)
        {
            Speed = Mathf.Lerp(Speed, -_backMaxSpeed, _acceleration * Time.fixedDeltaTime);
        }
        else
        {
            Speed = Mathf.Lerp(Speed, 0, _deceleration * Time.fixedDeltaTime);
        }

        Vector3 forwardMovement = transform.forward * Speed;
        _rb.velocity = new Vector3(forwardMovement.x, _rb.velocity.y, forwardMovement.z);
        if (_wheelsCtr != null) _wheelsCtr.RotationForward(Speed);
    }

    public void MoveBack(float verticalInput)
    {

    }

    public void TurnSide(float horizontalInput)
    {
        if (Mathf.Abs(Speed) > 0.1f)
        {
            float rotation = horizontalInput * RotationSpeed * Time.fixedDeltaTime * Speed;
            transform.Rotate(0, rotation, 0);
        }
        if (_wheelsCtr != null) _wheelsCtr.RotationTurn(horizontalInput);
    }

}
