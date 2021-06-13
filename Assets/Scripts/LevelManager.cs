using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int missDamage = 5;
    public int lifeCost = 3;
    public static GameObject player;
    public static PlayerController pc;
    Transform playerTrans;

    public static LevelManager instance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        instance = this;
    }

    public void NoteHit(GameObject blast) 
    {
        Instantiate(blast, playerTrans.position, playerTrans.transform.rotation);
    }

    public void LifeBlast(GameObject blast) 
    {
        Instantiate(blast, playerTrans.position, playerTrans.transform.rotation);
        pc.TakeDamage(lifeCost);
    }

    public void NoteMiss() 
    {
        pc.TakeDamage(missDamage);
    }

    public void DealDamage(int damage) 
    {
        pc.TakeDamage(damage);
    }
}
