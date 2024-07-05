using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private PoolObject originalObject;
    [SerializeField] private int amountOfCopies;
    [SerializeField] private List<PoolObject> availableObjects = new List<PoolObject>();

    private void Awake()
    {
        for(int index = 0; index < amountOfCopies; index++) {
            CreateCopy();
        }
    }

    private void CreateCopy()
    {
        PoolObject tmpObject = Instantiate(originalObject, transform);
        tmpObject.gameObject.SetActive(false);
        availableObjects.Add(tmpObject);
    }

    public PoolObject RetrieveAvailableItem()
    {
        if(availableObjects.Count == 0)
        {
            CreateCopy();
        }
        PoolObject tmpObject = availableObjects[0];
        availableObjects.RemoveAt(0);

        tmpObject.gameObject.SetActive(true);
        return tmpObject;
    }

    public void ResetBullet(PoolObject cloneObject)
    {
        cloneObject.gameObject.SetActive(false);
        availableObjects.Add(cloneObject);
    }
}
