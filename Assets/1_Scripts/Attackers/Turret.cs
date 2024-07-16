using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] float attackDistance;
    [SerializeField] Transform aim;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Sensor sensor;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float attackCooldown;

    private Ray ray;
    private RaycastHit rayTarget;
    private bool isPlayerInRange;
    private HealthModule playerHealth;
    private Player player;
    float timer = 0;


    private void Awake()
    {
        aim = transform.Find("aim");
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.sortingOrder = 1;
        lineRenderer.SetPosition(0, aim.position);
        sensor.OnPlayerEnter += SetPlayerInRange;
        sensor.OnPlayerExit += SetPlayerOutOfRange;
        HideRay();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange)
        {
            CreateRay();
        }
        
    }

    private void CreateRay()
    {
        ray = new Ray(aim.position, aim.transform.right);


        if (Physics.Raycast(ray, out rayTarget, attackDistance, interactableLayer))
        {
            DrawRay(rayTarget.point);
        }
        else if (Physics.Raycast(ray, out rayTarget, attackDistance, playerLayer))
        {
            DrawRay(rayTarget.point);
            //playerHealth = rayTarget.collider.GetComponent<HealthModule>();
            //playerHealth.DeductHealth(1);
            player = rayTarget.collider.GetComponent<Player>();

            timer += Time.deltaTime;
            if(timer >= attackCooldown)
            {
                player.ReceiveDamage(1);
                timer = 0;
            }
   
        }
        else
        {
            DrawRay(aim.position + aim.transform.right * attackDistance);
        }
    }

    private void DrawRay(Vector3 endPoint)
    {
        lineRenderer.SetPosition(1, endPoint);
    }

    private void HideRay()
    {
        lineRenderer.SetPosition(1, aim.position);
    }

    private void SetPlayerInRange()
    {
        isPlayerInRange = true;
    }

    private void SetPlayerOutOfRange()
    {
        isPlayerInRange = false;
        HideRay();
    }
}
