using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSensor : MonoBehaviour
{
    [SerializeField] DoorControl doorControl;
    private KeyNames keyName;

    private void Awake()
    {
        keyName = doorControl.GetDoorKeyName();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Key>())
        {
            if (other.gameObject.GetComponent<Key>().GetKeyName() == keyName)
            {
                if (other.gameObject.GetComponent<Key>().GetPickedUpStatus())
                {
                    doorControl.OpenDoor();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorControl.CloseDoor();
    }
}
