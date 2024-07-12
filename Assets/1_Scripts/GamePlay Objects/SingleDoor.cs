using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoor : Door
{
    [SerializeField] private Transform door;
    [SerializeField] private Transform openPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            door.position = Vector3.Lerp(door.position, openPoint.position, openingSpeed * Time.deltaTime);
        }
    }
}
