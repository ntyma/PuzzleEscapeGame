using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHintController : MonoBehaviour
{
    [SerializeField] private GameObject uiWindow;
    private bool doneReading = false;

    private void Start()
    {
        uiWindow.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!doneReading)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                uiWindow.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CloseWindow();
        }
    }

    public void CloseWindow()
    {
        doneReading = true;
        uiWindow.SetActive(false);
    }
}
