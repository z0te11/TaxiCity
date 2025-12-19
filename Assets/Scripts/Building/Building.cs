using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private int numberBuild;
    [SerializeField] private Transform _posToGetTaxi;

    public int GetNumberBuild()
    {
        return numberBuild;
    }

    public Transform GetPositionGetTaxi()
    {
        return _posToGetTaxi;
    }
}
