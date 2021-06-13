using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Color defaultColor;
    public Color pressedColor;
    public KeyCode keyToPress;
    public GameObject blast;


    private GameObject player;
    private PlayerController p_con;
    private SpriteRenderer sr;
    private int notes = 0;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        p_con = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            sr.color = pressedColor;
            if (notes == 0) 
            {
                LevelManager.instance.LifeBlast(blast);
            }
        }

        if (Input.GetKeyUp(keyToPress))
        {
            sr.color = defaultColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        notes++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        notes--;
    }
}
