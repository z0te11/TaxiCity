using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private int numberBuild;

    public int GetNumberBuild()
    {
        return numberBuild;
    }
}
