using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Events;

public class KeyBox : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private List<KeyNames> keys;
    [SerializeField] private List<KeyNames> keysIn;

    [SerializeField] private UnityEvent OnActivation;
    [SerializeField] private UnityEvent OnDeActivation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Key>())
        {
            KeyNames thisKey = other.gameObject.GetComponent<Key>().GetKeyName();
            if (keys.Contains(thisKey))
            {
                if (!keysIn.Contains(thisKey))
                {
                    keysIn.Add(thisKey);
                    CheckKeys();
                }
            }
        }
    }

    private void CheckKeys()
    {
        if(keys.Count == keysIn.Count)
        {
            door.OpenDoor();
        }
    }

}
