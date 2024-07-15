using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI MainText;
    [SerializeField] private GameStatus gameStatus;


    // Start is called before the first frame update
    void Start()
    {
        int status = gameStatus.GetPlayerStatus();
        if (status == 0)
        {
            SetFinishedLevelText();
        }
        else if (status == 1)
        {
            SetDeadText();
        } else if (status == 2)
        {
            SetCaughtText();
        }
    }

    private void SetFinishedLevelText()
    {
        MainText.text = "Congratuations!";
    }

    private void SetDeadText()
    {
        MainText.text = "Uh Oh. You Died.";
    }

    private void SetCaughtText()
    {
        MainText.text = "Uh Oh. You got caught.";
    }

}

