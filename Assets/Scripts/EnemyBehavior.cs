using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float fireRate = .5f;
    public GameObject bullet;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectile", 2.0f, fireRate);
    }

    void LaunchProjectile() 
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
