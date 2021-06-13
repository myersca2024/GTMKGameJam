using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public int damageVal = 4;
    public bool col; // true for red, false for blue
    Rigidbody2D bullet;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bullet = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            LevelManager.instance.DealDamage(damageVal);
        }

        if (col && collision.CompareTag("R_Blast"))
        {
            Destroy(this.gameObject);
        }
        else if (!col && collision.CompareTag("B_Blast"))
        {
            Destroy(this.gameObject);
        }
    }
}
