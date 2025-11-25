using UnityEngine;

public class DirectionArrow : MonoBehaviour
{   
    [SerializeField] private Transform _player; 
    [Header("Arrow Settings")]
    [SerializeField] private bool rotateInWorldSpace = true; 
    [Header("UI Arrow (Optional)")]
    [SerializeField] private RectTransform uiArrow; 
    [SerializeField] private Canvas canvas; 

    private Transform _target; 
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_target == null) return;

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
        Vector3 directionToTarget = _target.position - _player.position;
        
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
        // Получаем направление от игрока к цели в мировых координатах
        Vector3 worldDirection = _target.position - _player.position;
        
        // Преобразуем мировое направление в направление относительно камеры
        Vector3 cameraRelativeDirection = _mainCamera.transform.InverseTransformDirection(worldDirection);
        
        // Используем только X и Y компоненты для 2D направления
        Vector2 screenDirection = new Vector2(cameraRelativeDirection.x, cameraRelativeDirection.y).normalized;
        
        float angle = Mathf.Atan2(screenDirection.y, screenDirection.x) * Mathf.Rad2Deg;
        uiArrow.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }
}

