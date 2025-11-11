using System;
using UnityEngine;

public class CarMovement : MonoBehaviour, IMovementCar, ITransmission
{
    public static Action<int> OnStageChanged;
    public static Action<float> OnSpeedChanged;
    
    [Header("Movement Settings")]
    [SerializeField] private float _maxSpeed = 50f;
    [SerializeField] private float _backMaxSpeed = 10f;
    [SerializeField] private float _acceleration = 1f;
    [SerializeField] private float _deceleration = 1f;
    [SerializeField] private float _rotationSpeed = 8f;

    private Rigidbody _rb;
    private float _maxRotationSpeed;
    private int _stage;
    private int _maxStage = 5;
    private float _currentSpeed;
    private bool _canMove = true;

    public int Stage
    {
        get { return _stage; }
        set
        {
            if (value <= _maxStage && value > 0) _stage = value;
            OnStageChanged?.Invoke(_stage);
        }
    }

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
    }

    private void Start()
    {
        _maxRotationSpeed = _rotationSpeed;
        Stage = 1;
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
            var newAccel = Utils.CalculateAcceleration(Stage, _acceleration, Speed);
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
    }

    public void NextStage()
    {
        Stage++;
    }

    public void PreviousStage()
    {
        Stage--;
    }

}
