using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sensor : MonoBehaviour
{
    public Action OnPlayerEnter;
    public Action OnPlayerExit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            OnPlayerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerExit.Invoke();
        }
    }


}
