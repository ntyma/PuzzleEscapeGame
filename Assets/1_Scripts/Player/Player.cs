using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private HealthModule health;
    public Action OnPlayerDeath;
    [SerializeField] private Transform startPoint;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthModule>();
        health.OnDie += PlayerDied;
        GameManager.singleton.OnActionLevelStart += MovetoStartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerDied()
    {
        OnPlayerDeath.Invoke();
    }

    public void ReceiveDamage(float damage)
    {
        health.DeductHealth(damage);
    }

    private void MovetoStartPosition()
    {
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;
    }
}
