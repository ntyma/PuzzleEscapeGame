using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private Sensor room2Sensor;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.singleton.OnUnityLevelStart.AddListener(StartCutscene);
        //GameManager.singleton.OnActionLevelStart += StartCutscene;
        room2Sensor.OnPlayerEnter += StartCutscene;
        room2Sensor.OnPlayerExit -= ExitTrigger;
    }
 
    private void StartCutscene()
    {
        Debug.Log("activate cut scene");
        GameManager.singleton.LockPlayerInput();
        
        director.gameObject.SetActive(true);
    }

    public void OnCutsceneEnd()
    {
        //GameManager.singleton.OnUnityLevelStart.RemoveListener(StartCutscene);
        //GameManager.singleton.OnActionLevelStart -= StartCutscene;
        director.gameObject.SetActive(false);
        GameManager.singleton.UnlockPlayerInput();
    }

    private void ExitTrigger()
    {
        room2Sensor.OnPlayerEnter -= StartCutscene;
        room2Sensor.OnPlayerExit -= ExitTrigger;
    }
}

public enum CutsceneStartType
{
    OnLevelStart, OnLevelFinish
}
