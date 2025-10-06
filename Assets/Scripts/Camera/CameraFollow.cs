using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float height = 15f;
    public float distance = 10f;
    public float smoothSpeed = 0.125f;
    
    void Update()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + Vector3.up * height - target.forward * distance;
            
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            
            transform.LookAt(target);
        }
    }
}
