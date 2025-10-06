using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    private Renderer _render;

    private void Start()
    {
        _render = GetComponent<Renderer>();
    }

    public void SetShader(Shader newShader)
    {
        _render.material.shader = newShader;
    }

}
