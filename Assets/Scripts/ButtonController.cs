using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Color defaultColor;
    public Color pressedColor;
    public KeyCode keyToPress;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            sr.color = pressedColor;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            sr.color = defaultColor;
        }
    }
}
