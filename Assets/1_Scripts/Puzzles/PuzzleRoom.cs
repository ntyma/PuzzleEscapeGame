using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRoom : MonoBehaviour
{
    [SerializeField] private bool isComplete;
    [SerializeField] private bool isCurrentPuzzle;

    private void OnTriggerEnter(Collider other)
    {
        isCurrentPuzzle = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isCurrentPuzzle = false;
    }
}
