using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WalkingModule : MonoBehaviour
{

    [Header("Aiming")]
    private Vector3 moveDirection;
    private Vector2 aimDirection;
    [SerializeField] private float speed;
    [SerializeField] private float sprintingMultiplier;
    [SerializeField] private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        float tempMultiplier = 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            tempMultiplier = sprintingMultiplier;
        }
        controller.Move(((transform.right * moveDirection.x) + (transform.forward * moveDirection.z)) * Time.deltaTime * speed * tempMultiplier);
    }
}
