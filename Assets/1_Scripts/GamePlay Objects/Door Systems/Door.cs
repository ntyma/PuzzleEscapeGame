using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] protected float openingSpeed;
    protected bool isOpen = false;
    [SerializeField] private AudioSource audioPlayer;

    public virtual void OpenDoor()
    {
        isOpen = true;
        PlayAudio();
    }

    public virtual void CloseDoor()
    {
        isOpen = false;
        PlayAudio();
    }

    private void PlayAudio()
    {
        if (audioPlayer != null)
        {
            audioPlayer.Play();
        }
    }
}
