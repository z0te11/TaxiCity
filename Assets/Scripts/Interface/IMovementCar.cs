
using UnityEngine;

interface IMovementCar
{
    public float Speed { get; set; }
    public void Move(Vector2 pos);
    public void MoveForward(float verticalInput);

    public void MoveBack(float verticalInput);

    public void TurnSide(float horizontalInput);
}
