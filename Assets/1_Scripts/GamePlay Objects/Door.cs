using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private KeyNames keyName;
    // Start is called before the first frame update

    public virtual void OpenDoor()
    {

    }

    public virtual void CloseDoor()
    {

    }

    public KeyNames GetDoorKeyName()
    {
        return keyName;
    }
}
