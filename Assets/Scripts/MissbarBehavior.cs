using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissbarBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RedNote") || collision.CompareTag("BlueNote"))
        LevelManager.instance.NoteMiss();
    }
}
