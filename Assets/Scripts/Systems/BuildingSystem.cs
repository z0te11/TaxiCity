using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] private GameObject _builds;
    private Building[] _buildings;

    public static BuildingSystem instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        _buildings = _builds.GetComponentsInChildren<Building>();
    }

    public Vector3 GetPositionBuilding(int numberBuild)
    {
        for (int i = 0; i < _buildings.Length; i++)
        {
            int newNumber = _buildings[i].GetNumberBuild();
            if (i == numberBuild) return _buildings[i].gameObject.transform.position;
        }
        return Vector3.zero;
    }
}
