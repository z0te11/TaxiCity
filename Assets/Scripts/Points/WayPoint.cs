using UnityEngine;

public class WayPoint : MonoBehaviour
{
    private Renderer _render;
    private OrderSystem _orderSystem;
    private WaySystem _waySystem;

    public void Initialize(OrderSystem orderSystem, WaySystem waySystem)
    {
        _orderSystem = orderSystem;
        _waySystem = waySystem;
    }

    private void Awake()
    {
        _render = GetComponentInChildren<Renderer>();
    }

    public void SetShader(Material newMaterial)
    {
        _render.material = newMaterial;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (_orderSystem.currnetOrder == null) return;
        _waySystem.NextWayRoad();
        DestroyPoint();
    }
    
    public void DestroyPoint()
    {
        Destroy(gameObject);
    }

}
