using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton{get; private set;}
    [SerializeField] private InputController player;

    public UnityEvent OnUnityLevelStart = new UnityEvent();
    public Action OnActionLevelStart;

    public UnityEvent OnUnityLevelEnd = new UnityEvent();
    public Action OnActionLevelEnd;

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
    }

    //Needs to be called at every scene transition
    public void StartLevel()
    {
        player = FindObjectOfType<InputController>();
        OnUnityLevelStart?.Invoke();
        OnActionLevelStart?.Invoke();
    }

    public void FinishLevel()
    {
        OnUnityLevelEnd?.Invoke();
        OnActionLevelEnd?.Invoke();
    }

    public void PlayerDied()
    {

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
