using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    private Transform target; 
    
    [Header("Arrow Settings")]
    [SerializeField] private bool rotateInWorldSpace = true; 
    [SerializeField] private bool showDebugRay = true; 
    [SerializeField] private Color debugRayColor = Color.red; 

    [Header("UI Arrow (Optional)")]
    [SerializeField] private RectTransform uiArrow; 
    [SerializeField] private Canvas canvas; 

    private void Update()
    {
        if (target == null) return;

        UpdateArrowDirection();
    }

    private void UpdateArrowDirection()
    {
        if (uiArrow != null && canvas != null)
        {
            UpdateUIArrowDirection();
        }
        else
        {
            UpdateWorldArrowDirection();
        }
    }

    private void UpdateWorldArrowDirection()
    {
        Vector3 directionToTarget = target.position - transform.position;
        
        if (directionToTarget.sqrMagnitude < 0.001f) return;

        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        
        if (rotateInWorldSpace)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    private void UpdateUIArrowDirection()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, target.position);
        Vector2 localPoint;
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, 
            screenPoint, 
            canvas.worldCamera, 
            out localPoint);

        Vector2 direction = (localPoint - (uiArrow.anchoredPosition)).normalized;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        uiArrow.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

}
