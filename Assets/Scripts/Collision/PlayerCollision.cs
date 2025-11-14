using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private CarMovement _carMove;
    private void Awake()
    {
        _carMove = GetComponent<CarMovement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_carMove == null) return;
         _carMove.Speed = 0;

        if (collision.gameObject.GetComponent<Building>())
        {
           
        }
    }
}
