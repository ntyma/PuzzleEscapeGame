using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIndicator : MonoBehaviour
{
    [SerializeField] Key key;
    private Material originalMaterial;
    [SerializeField] private Material unlockedMaterial;
    private MeshRenderer meshRenderer;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
        key.OnPickedUp += IndicatePlayerHasKey;
        key.OnDropped += ResetIndicator;
    }

    private void IndicatePlayerHasKey()
    {
        meshRenderer.material = unlockedMaterial;
    }

    private void ResetIndicator()
    {
        meshRenderer.material = originalMaterial;
    }

}
