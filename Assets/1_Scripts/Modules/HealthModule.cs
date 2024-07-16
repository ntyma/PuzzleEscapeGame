using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthModule: MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    public Action<float> OnHealthChanged;
    public Action OnDie;

    //public HealthModule(int maxHealth)
    //{
    //    currentHealth = maxHealth;
    //}

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void DeductHealth(float toDeduct)
    {
        currentHealth -= toDeduct;
        OnHealthChanged.Invoke(currentHealth);
        
        if(currentHealth <= 0)
        {
            OnDie.Invoke();
        }
    }
}
