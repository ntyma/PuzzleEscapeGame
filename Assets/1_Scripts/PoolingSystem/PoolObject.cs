using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private ObjectPool poolOwner;
    public Rigidbody rigidbody;

    public void LinkToPool(ObjectPool owner)
    {
        poolOwner = owner;
    }

    public void ResetBackToPool()
    {
        rigidbody.velocity = Vector3.zero;
        poolOwner.ResetBullet(this);
    }

    public void ResetBackToPool(float time)
    {
        Invoke(nameof(ResetBackToPool), time);
    }
}
