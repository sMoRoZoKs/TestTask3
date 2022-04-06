using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private Material defaultMaterial;
    [SerializeField] private Material infectionMaterial;
    [SerializeField] private MeshRenderer meshRenderer;
    private bool _infected = false;
    private void Start()
    {
        defaultMaterial = meshRenderer.material;
    }
    public void Infection()
    {
        _infected = true;
        meshRenderer.material = infectionMaterial;
        Invoke(nameof(Boom), 3);
    }
    private void Boom()
    {
        Destroy(gameObject);
    }
    public bool Infected => _infected;
}
