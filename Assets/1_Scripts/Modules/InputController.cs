using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Receives Input and calls appropriate classes
public class InputController : MonoBehaviour
{
    [SerializeField] private ShootingModule shootingModule;
    [SerializeField] private InteractModule interactModule;
    [SerializeField] private WalkingModule walkingModule;
    [SerializeField] private CommandInteractor commandInteractor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shootingModule != null)
        {
            shootingModule.Shoot();
        }
        
        if(commandInteractor != null && Input.GetMouseButtonDown(1))
        {
            commandInteractor.CreateCommand();
        }

        if (Input.GetKeyDown(KeyCode.E) && interactModule != null)
        {
            interactModule.InteractWithObject();
        }
        if(walkingModule != null)
        {
            walkingModule.MovePlayer();
        }
    }
}
