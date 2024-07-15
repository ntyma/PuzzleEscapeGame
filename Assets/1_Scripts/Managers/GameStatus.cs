using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    private string playerStatus;

    private void Awake()
    {
        
    }

    public void SetPlayerCompleted()
    {
        PlayerPrefs.SetInt(playerStatus, 0);
    }

    public void SetPlayerDied()
    {
        PlayerPrefs.SetInt(playerStatus, 1);
    }

    public void SetPlayerCaught()
    {
        PlayerPrefs.SetInt(playerStatus, 2);
    }

    public int GetPlayerStatus()
    {
        return PlayerPrefs.GetInt(playerStatus);
    }
}
