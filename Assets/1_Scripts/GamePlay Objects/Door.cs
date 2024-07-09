using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private KeyNames keyName;
    [SerializeField] protected float openingSpeed;
    protected bool isOpen = false;
    // Start is called before the first frame update

    public virtual void OpenDoor()
    {
        isOpen = true;
    }

    public virtual void CloseDoor()
    {
        isOpen = false;
    }

    public KeyNames GetDoorKeyName()
    {
        return keyName;
    }
}
