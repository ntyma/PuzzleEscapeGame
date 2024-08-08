using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject controllerMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        controllerMenu.SetActive(false);
    }

    public void ShowControlls()
    {
        mainMenu.SetActive(false);
        controllerMenu.SetActive(true);
    }
}
