using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent OnInteracted;
    [SerializeField] private Material hoverMaterial;

    private Material originalMaterial;
    private MeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        originalMaterial = mesh.material;
    }

    public void OnHoverEnter()
    {
        Debug.Log("Hovering on button");
        mesh.material = hoverMaterial;
    }

    public void OnHoverExit()
    {
        Debug.Log("Stopped hovering on button");
        mesh.material = originalMaterial;
    }

    public void OnInteract(InteractModule player)
    {
            OnInteracted.Invoke();
            Debug.Log("Pressed the button");
    }
      
}
