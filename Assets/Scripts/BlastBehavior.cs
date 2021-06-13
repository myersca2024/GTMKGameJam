using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBehavior : MonoBehaviour
{

    public float growthSpeed = .001f;
    public float duration = 2;
    public string enemyTag;
    public string bulletTag;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newSize = transform.localScale;

        newSize.x += growthSpeed;
        newSize.y += growthSpeed;

        transform.localScale = newSize;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag)) 
        {
            Destroy(collision.gameObject);
        }
    }
}
