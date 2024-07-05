using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void OnHoverEnter();

    public void OnHoverExit();

    public void OnInteract(InteractModule player);
}
