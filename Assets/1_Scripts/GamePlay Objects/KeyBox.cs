using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Events;

public class KeyBox : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private List<Key> keyObjects;
    [SerializeField] private List<KeyNames> keys;
    [SerializeField] private List<KeyNames> keysIn;

    [SerializeField] private GameObject box;
    private MeshRenderer meshRenderer;

    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material highlightMaterial;

    //[SerializeField] private UnityEvent OnActivation;
    //[SerializeField] private UnityEvent OnDeActivation;

    private void Start()
    {
        meshRenderer = box.GetComponent<MeshRenderer>();
        normalMaterial = meshRenderer.material;
        foreach(Key key in keyObjects)
        {
            keys.Add(key.GetKeyName());
            key.OnPickedUp += HighlightBox;
            key.OnDropped += UnhighlightBox;
        }
    }


    private void HighlightBox()
    {
        meshRenderer.material = highlightMaterial;
    }

    private void UnhighlightBox()
    {
        meshRenderer.material = normalMaterial;
    }


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
