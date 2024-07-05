using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Camera camera;
    //[SerializeField] private Rigidbody projectile;
    //[SerializeField] private Transform shootingPoint;

    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float sprintingMultiplier;

    [SerializeField] private Vector3 velocity;
    [SerializeField] private LayerMask floorLayer;

    [Header("Aiming")]
    private Vector3 moveDirection;
    private Vector2 aimDirection;
    private bool CanLookWithMouse;
    //[SerializeField] Transform holdPoint;


    [Header("Interactions")]
    //[SerializeField] private LayerMask interactableLayer;
    [SerializeField] Transform holdPoint;

    private float gravityAcceleration = -9.81f;
    //private IInteractable targetInteractable;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        //controller = GetComponent<CharacterController>();
        
        aimDirection.y = 0;

        
    }

    private void Update()
    {
        //MovePlayer();
        RotatePlayer();
        Jump();
        ApplyGravity();
        //Interact();
        
    }



    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            velocity.y = jumpForce;
        }
    }

    private void ApplyGravity()
    {

        if (!IsGrounded())
        {
            velocity.y += gravityAcceleration * Time.deltaTime;

            if (velocity.y < -5f)
            {
                velocity.y = -5f;
            }
        }
        else if (velocity.y < 0)
        {
            velocity.y = 0;
        }
        controller.Move(velocity * Time.deltaTime);
    }



    private void RotatePlayer()
    {
        aimDirection.x = Input.GetAxisRaw("Mouse X");
        //TODO : += to keep track of how much to rotate when rotating up and down
        aimDirection.y += -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSensitivity;

        //camera.transform.Rotate(Vector3.right, -aimDirection.y * Time.deltaTime * mouseSensitivity);

        aimDirection.y = Mathf.Clamp(aimDirection.y, -85f, 85f);
        camera.transform.localEulerAngles = new Vector3(aimDirection.y, 0, 0);
        transform.Rotate(Vector3.up, aimDirection.x * Time.deltaTime * mouseSensitivity);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.25f, floorLayer);
    }
}
