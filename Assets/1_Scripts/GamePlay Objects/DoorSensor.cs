using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSensor : MonoBehaviour
{
    [SerializeField] Door door;
    [SerializeField] private KeyNames keyName;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Key>())
        {
            if (other.gameObject.GetComponent<Key>().GetKeyName() == keyName)
            {
                if (other.gameObject.GetComponent<Key>().GetPickedUpStatus())
                {
                    door.OpenDoor();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        door.CloseDoor();
    }
}
