using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private AIController myController;
    float timer = 0;
    private Player player;
    [SerializeField] private float attackCooldown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myController.ChangeState(new ChaseState(myController, other.transform));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;
            player = other.GetComponent<Player>();
            if (timer >= attackCooldown)
            {
                player.ReceiveDamage(2);
                timer = 0;
            }

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        myController.ChangeState(new PatrolState(myController));
    }
}
