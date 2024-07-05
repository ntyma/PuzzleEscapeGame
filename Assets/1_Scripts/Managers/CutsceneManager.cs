using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.singleton.OnUnityLevelStart.AddListener(StartCutscene);
        GameManager.singleton.OnActionLevelStart += StartCutscene;


    }
 
    private void StartCutscene()
    {
        director.Play();
    }

    private void OnCutsceneEnd()
    {
        GameManager.singleton.OnUnityLevelStart.RemoveListener(StartCutscene);
        GameManager.singleton.OnActionLevelStart -= StartCutscene;
    }
}

public enum CutsceneStartType
{
    OnLevelStart, OnLevelFinish
}
