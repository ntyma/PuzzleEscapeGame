using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    private Rigidbody rb;
    private Transform point;
    protected bool isPickedUp;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnHoverEnter()
    {
        Debug.Log("Hover Enter");
    }

    public void OnHoverExit()
    {
        Debug.Log("Hover Exit");
    }

    public void OnInteract(InteractModule player)
    {
        //PickUp();
        Debug.Log("Attempting pickup");

        //Pickable is not being held
        if(transform.parent == null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;

            point = player.GetHoldTransform();
            transform.position = point.position;
            transform.rotation = point.rotation;
            transform.SetParent(point);

            IndicatePickedUp();
            
            Debug.Log("Picking up box");
        }
        else //picakble is being held
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            transform.SetParent(null);

            IndicateDropped();
        }
        
    }

    protected virtual void IndicatePickedUp()
    {
        isPickedUp = true;
    }

    protected virtual void IndicateDropped()
    {
        isPickedUp = false;
    }
}
