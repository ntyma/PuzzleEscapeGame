using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private KeyNames keyName;
    private Material originalMaterial;
    [SerializeField] private Material unlockedMaterial;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    public void OpenDoor()
    {
        Debug.Log("=== DOOR OPENING===");
        meshRenderer.material = unlockedMaterial;
        animator.SetBool("DoorOpen", true);
    }

    public void CloseDoor()
    {
        Debug.Log("=== DOOR CLOSING===");
        meshRenderer.material = originalMaterial;
        animator.SetBool("DoorOpen", false);
    }

    public KeyNames GetDoorKeyName()
    {
        return keyName;
    }
}
