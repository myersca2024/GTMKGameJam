using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject blast;
    GameObject player;

    private Transform playerTrans;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;

    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                DestroyNote();
                LevelManager.instance.NoteHit(blast);
            }
        }
    }

    void DestroyNote()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, .05f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Button")
        {
            canBePressed = true;
        }
    }
}
