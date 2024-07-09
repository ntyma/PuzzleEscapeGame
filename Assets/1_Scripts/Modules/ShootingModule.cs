using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingModule : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;


    [SerializeField] private Camera camera;
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float forceFactor;

    public void Shoot()
    {
        //create projectile
        //Rigidbody bulletInstantiated = Instantiate(projectile, shootingPoint.transform.position, shootingPoint.transform.rotation);

        PoolObject tempPool = pool.RetrieveAvailableItem();

        //Rigidbody bulletInstantiated = tempPool.GetComponent<Rigidbody>();
        Rigidbody bulletInstantiated = tempPool.rigidbody;
        bulletInstantiated.position = shootingPoint.position;
        bulletInstantiated.rotation = shootingPoint.rotation;

        //TODO: for projectiles need to add foremode.impuls for realistic shooting
        bulletInstantiated.AddForce(forceFactor * shootingPoint.forward, ForceMode.Impulse);
        Destroy(bulletInstantiated.gameObject, 5f);

        tempPool.ResetBackToPool(5f);
    }
}
