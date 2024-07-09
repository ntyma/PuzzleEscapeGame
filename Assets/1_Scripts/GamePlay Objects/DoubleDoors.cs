using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoors : Door
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    [SerializeField] private float doorLength;

    [SerializeField] private Vector3 leftOriginalPosition;
    [SerializeField] private Vector3 rightOriginalPosition;
    [SerializeField] private Vector3 leftOpenPosition;
    [SerializeField] private Vector3 rightOpenPosition;


    public void Start()
    {
        leftOriginalPosition = leftDoor.transform.position;
        rightOriginalPosition = rightDoor.transform.position;

        leftOpenPosition = leftOriginalPosition;
        rightOpenPosition = rightOriginalPosition;

        leftOpenPosition.z += doorLength;
        rightOpenPosition.z -= doorLength;     
    }

    private void Update()
    {
        if (isOpen)
        {
            leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, leftOpenPosition, openingSpeed * Time.deltaTime);
            rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, rightOpenPosition, openingSpeed * Time.deltaTime);
        }
    }

}
