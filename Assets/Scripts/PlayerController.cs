using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float speed = 5;
    public Rigidbody2D rb;
    public float blockTime = 1f;
    public Slider healthBar;

    string blockType = "";
    float blockTimer = 0f;

    Vector2 movement;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    private void Update()
    {
        if (!blockType.Equals(""))
        {
            blockTimer += Time.deltaTime;
            if (blockTimer >= blockTime)
            {
                blockType = "";
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerBlocked("Red");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerBlocked("Blue");
        }
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void PlayerBlocked(string type)
    {
        blockType = type;
        blockTimer = 0f;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.value = currentHealth;
        Debug.Log("Ouch! Current health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Player Died!!!!!");
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedEnemy"))
        {
            if (!blockType.Equals("Red"))
            {
                TakeDamage(10);
            }
        }

        if (collision.gameObject.CompareTag("BlueEnemy"))
        {
            if (!blockType.Equals("Blue"))
            {
                TakeDamage(10);
            }
        }
    }
}
