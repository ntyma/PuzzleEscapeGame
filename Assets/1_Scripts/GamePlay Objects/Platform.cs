using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform platform;
    [SerializeField] private float speed;
    [SerializeField] private Transform endPoint;
    [SerializeField] private TargetButton targetButton;

    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        targetButton.OnHit += RevealPlatform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            platform.position = Vector3.Lerp(platform.position, endPoint.position, speed * Time.deltaTime);
        }
    }

    private void RevealPlatform()
    {
        isOpen = true;
    }
}
