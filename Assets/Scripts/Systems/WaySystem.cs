using System.Collections.Generic;
using UnityEngine;

public class WaySystem : MonoBehaviour
{
    [SerializeField] private GameObject _wayPoint;
    [SerializeField] private Material _startMaterial;
    [SerializeField] private Material _neutralMaterial;
    [SerializeField] private Material _finishMaterial;
    private int _numberWay = 0;
    private WayPosition _currentWayPos;

    public static WaySystem instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void CreateWayRoad(WayPosition wayPos)
    {
        _currentWayPos = wayPos;
        CreateWayPoint(_currentWayPos.points[_numberWay], _startMaterial);
    }

    private void CreateWayPoint(Vector3 pos, Material newMaterial)
    {
        var newWayPoint = Instantiate(_wayPoint, pos, Quaternion.identity);
        var pointComp = newWayPoint.GetComponent<WayPoint>();
        pointComp.SetShader(newMaterial);
    }

    public void NextWayRoad()
    {
        _numberWay++;
        var newMaterial = _startMaterial;
        if (_numberWay < _currentWayPos.points.Count)
        {
            newMaterial = _neutralMaterial;
        }
        else
        {
            newMaterial = _finishMaterial;
        }
        CreateWayPoint(_currentWayPos.points[_numberWay], newMaterial);
    }
}


public struct WayPosition
{
    public List<Vector3> points;
}
