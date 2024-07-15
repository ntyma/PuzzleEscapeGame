using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton{get; private set;}
    private InputController player;
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private GameStatus gameStatus;

    //public UnityEvent OnUnityLevelStart = new UnityEvent();
    public Action OnActionLevelStart;

    //public UnityEvent OnUnityLevelEnd = new UnityEvent();
    public Action OnActionLevelCompleted;

    [SerializeField] private Sensor ExitSensor;

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        StartLevel();
        ExitSensor.OnPlayerEnter += FinishLevel;
    }

    //Needs to be called at every scene transition
    public void StartLevel()
    {
        player = FindObjectOfType<InputController>();
        UnlockPlayerInput();
        //OnUnityLevelStart?.Invoke();
        OnActionLevelStart?.Invoke();
    }

    public void FinishLevel()
    {
        //OnUnityLevelEnd?.Invoke();
        //OnActionLevelCompleted?.Invoke();
        gameStatus.SetPlayerCompleted();
        LockPlayerInput();
        levelLoader.LoadEndScene();
    }

    public void PlayerDied()
    {
        gameStatus.SetPlayerDied();
        LockPlayerInput();
        levelLoader.LoadEndScene();
    }

    public void PlayerCaught()
    {
        gameStatus.SetPlayerCaught();
        LockPlayerInput();
        levelLoader.LoadEndScene();
    }

    public void LockPlayerInput()
    {
        player.enabled = false;
    }

    public void UnlockPlayerInput()
    {
        player.enabled = true;
    }
}
