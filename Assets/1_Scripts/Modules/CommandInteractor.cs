using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CommandInteractor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Queue<Command> commands = new Queue<Command>();
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask clickableLayer;

    private Command currentCommand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentCommand != null)
        //{
        //    currentCommand.Execute();
        //    if (currentCommand.IsCompleted())
        //    {
        //        if (commands.Count == 0)
        //        {
        //            return;
        //        }
        //        currentCommand = commands.Dequeue();
        //        Debug.Log("QUEUE COUNT: " + commands.Count);
        //    }
        //}
        //else if (commands.Count != 0)
        //{
        //    currentCommand = commands.Dequeue();
        //}


        if (currentCommand != null)
        {
            currentCommand.Execute();
            if (currentCommand.IsCompleted())
            {
                currentCommand = null;
            }
        }
        else
        {
            if (commands.Count == 0)
            {
                return;
            }
            currentCommand = commands.Dequeue();
            Debug.Log("QUEUE COUNT: " + commands.Count);
        }


    }

    public void CreateCommand()
    {
        
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f, clickableLayer))
        {
            agent.SetDestination(hit.point);
            Debug.Log("Moveto position" + hit.point);
            commands.Enqueue(new MoveCommand(agent, hit.point));
        }

        

    }
}
