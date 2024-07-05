using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private AIController myController;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("player enter");
        myController.ChangeState(new ChaseState(myController, other.transform));    
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("player exit");
        myController.ChangeState(new PatrolState(myController));
    }
}
