using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private HealthModule health; 
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthModule>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDamage(float damage)
    {
        health.DeductHealth(damage);
    }
}
