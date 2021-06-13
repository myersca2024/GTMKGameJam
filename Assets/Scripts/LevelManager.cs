using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public int missDamage = 5;
    public int lifeCost = 3;
    public static GameObject player;
    public static PlayerController pc;
    Transform playerTrans;
    public GameObject gameOverScreen;
    public AudioSource music;

    public static LevelManager instance;

    private bool isGameOver = false;
    private float waitTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        instance = this;
    }

    private void Update()
    {
        waitTime += Time.deltaTime;

        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RhythmManager.gameRunning = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (!music.isPlaying && waitTime > 10f)
        {
            SceneManager.LoadScene(0);
        }
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

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        music.Stop();
        RhythmManager.gameRunning = false;
        isGameOver = true;
    }
}
