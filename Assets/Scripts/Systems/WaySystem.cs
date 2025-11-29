using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WaySystem : MonoBehaviour
{
    [SerializeField] private DirectionArrow _arrow;
    [SerializeField] private GameObject _wayPoint;
    [SerializeField] private Material _startMaterial;
    [SerializeField] private Material _neutralMaterial;
    [SerializeField] private Material _finishMaterial;
    private int _numberWay = 0;
    private List<int> _currentWayPos = new List<int>();

    private OrderSystem _orderSystem;
    private BuildingSystem _buildingSystem;

    [Inject]
    public void Construct(OrderSystem orderSystem, BuildingSystem buildingSystem)
    {
        _orderSystem = orderSystem;
        _buildingSystem = buildingSystem;
    }

    public void CreateWayRoad(List<int> wayPos)
    {
        _numberWay = 0;
        _currentWayPos = wayPos;
        Vector3 wayFirstPos = _buildingSystem.GetPositionBuilding(_currentWayPos[_numberWay]);
        CreateWayPoint(wayFirstPos, _startMaterial);
    }

    private void CreateWayPoint(Vector3 pos, Material newMaterial)
    {
        var newWayPoint = Instantiate(_wayPoint, pos, Quaternion.identity);
        _arrow.SetTarget(newWayPoint.transform);
        var pointComp = newWayPoint.GetComponent<WayPoint>();
        pointComp.Initialize(_orderSystem, this);
        pointComp.SetShader(newMaterial);
    }

    public void NextWayRoad()
    {
        _numberWay++;
        if (_numberWay >= _currentWayPos.Count)
        {
            _orderSystem.FinishOrder();
            return;
        }

        var newMaterial = _startMaterial;
        if (_numberWay < _currentWayPos.Count - 1)
        {
            newMaterial = _neutralMaterial;
        }
        else
        {
            newMaterial = _finishMaterial;
        }
        CreateWayPoint(_buildingSystem.GetPositionBuilding(_currentWayPos[_numberWay]), newMaterial);
    }
}


