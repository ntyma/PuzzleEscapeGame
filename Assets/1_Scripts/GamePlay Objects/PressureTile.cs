using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressureTile : MonoBehaviour
{
    [SerializeField] private Rigidbody correctRigidbody;
    [SerializeField] private UnityEvent OnActivation;
    [SerializeField] private UnityEvent OnDeActivation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody == correctRigidbody)
        {
            OnActivation.Invoke();
            Debug.Log("box on trigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody == correctRigidbody)
        {
            OnDeActivation.Invoke();
            Debug.Log("box on trigger");
        }
    }
}
