using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene(2);
    }
}
