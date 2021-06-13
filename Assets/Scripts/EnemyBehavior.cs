using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float fireRate = .5f;
    public float speed = 5f;
    public GameObject bullet;
    public Transform firePoint;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("LaunchProjectile", 2.0f, fireRate);
    }

    private void Update()
    {
        if (RhythmManager.gameRunning)
        {
            Vector3 diff = player.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }

    void LaunchProjectile() 
    {
        GameObject ammo = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = ammo.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
    }
}
