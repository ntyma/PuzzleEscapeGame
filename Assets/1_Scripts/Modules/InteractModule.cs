using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractModule : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask interactableLayer;
    private IInteractable targetInteractable;

    [SerializeField] Transform holdPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
    }

    public void InteractWithObject()
    {
        if (targetInteractable != null)
        {
            targetInteractable.OnInteract(this);
        }
            
    }

    private void CheckInteraction()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f, interactableLayer))
        {
            if (targetInteractable == null)
            {
                targetInteractable = hit.collider.GetComponent<IInteractable>();
                targetInteractable.OnHoverEnter();
            }
            else
            {
                //
            }
            //Debug.Log(hit.collider.gameObject.name)
        }
        else if (targetInteractable != null)
        {
            targetInteractable.OnHoverExit();
            targetInteractable = null;
        }
        //Debug.DrawRay(ray.origin, ray.direction, Color.red, 3f);


    }

    public Transform GetHoldTransform()
    {
        return holdPoint;
    }
}
