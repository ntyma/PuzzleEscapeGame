using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetButton : MonoBehaviour
{
    [SerializeField] private LayerMask projectileLayer;
    public Action OnHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            Debug.Log("hit the target");
            OnHit.Invoke();
        }
    }
}
