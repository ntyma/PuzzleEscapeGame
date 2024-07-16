using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Key : Pickable
{
    [SerializeField] private KeyNames keyName;
    public Action OnPickedUp;
    public Action OnDropped;

    public bool GetPickedUpStatus()
    {
        return isPickedUp;
    }

    public KeyNames GetKeyName()
    {
        return keyName;
    }

    protected override void IndicatePickedUp()
    {
        base.IndicatePickedUp();
        OnPickedUp.Invoke();
    }

    protected override void IndicateDropped()
    {
        base.IndicateDropped();
        OnDropped.Invoke();
    }
}
