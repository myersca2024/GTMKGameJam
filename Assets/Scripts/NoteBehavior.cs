using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                DestroyNote();
            }
            else
            {
                MissedNote();
            }
        }
    }

    void DestroyNote()
    {
        gameObject.SetActive(false);
    }

    void MissedNote()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Sad");
        if (collision.tag == "Button")
        {
            canBePressed = true;
        }
        else if (collision.tag == "MissBar")
        {
            MissedNote();
            DestroyNote();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Button")
        {
            canBePressed = false;
        }
    }
}
