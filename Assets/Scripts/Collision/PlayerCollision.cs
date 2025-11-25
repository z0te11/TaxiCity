using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private CarPlayerMovement _carMove;
    private void OnCollisionEnter(Collision collision)
    {
        if (_carMove == null) return;
         _carMove.Speed = 0;

        if (collision.gameObject.GetComponent<Building>())
        {
           
        }
    }
}
