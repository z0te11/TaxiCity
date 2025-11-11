using UnityEngine;

public class WayPoint : MonoBehaviour
{
    private Renderer _render;

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
        if (OrderSystem.instance.currnetOrder == null) return;
        WaySystem.instance.NextWayRoad();
        DestroyPoint();
    }
    
    public void DestroyPoint()
    {
        Destroy(gameObject);
    }

}
