using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    public GameObject redButton;
    public GameObject blueButton;
    public BeatScroller redArrow;
    public BeatScroller blueArrow;
    public string filePath;
    public float scrollSpeed;
    public AudioSource music;

    private string[] keyframes;
    private int keyframeIndex = 0;
    private float bpm;
    private float currentTime = 0f;
    public float topScreen = 7.55f;

    void Start()
    {
        keyframes = System.IO.File.ReadAllLines(@filePath);
        bpm = float.Parse(keyframes[keyframeIndex]);
        keyframeIndex++;
        music.Play();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        
        if (keyframeIndex < keyframes.Length)
        {
            ProcessCurrentLine();
        }
    }

    void ProcessCurrentLine()
    {
        string[] keyframe = keyframes[keyframeIndex].Split(' ');
        if (keyframe.Length > 0 && float.Parse(keyframe[0]) <= CurrentBeat())
        {
            //Debug.Log(keyframe[0] + " " + CurrentBeat().ToString());
            for (int ii = 1; ii < keyframe.Length; ii++)
            {
                if (keyframe[ii] == "R")
                {
                    SpawnRedArrow();
                }
                else if (keyframe[ii] == "B")
                {
                    SpawnBlueArrow();
                }
            }
            keyframeIndex++;
        }
    }
    
    // Turns given time into current beat in song
    float CurrentBeat()
    {
        return bpm / 60 * currentTime;
    }

    void SpawnRedArrow()
    {
        BeatScroller arrow = Instantiate(redArrow, 
            new Vector3(redButton.transform.position.x, redButton.transform.position.y + topScreen, 0), redButton.transform.localRotation);
        arrow.BPM = this.bpm * scrollSpeed;
    }

    void SpawnBlueArrow()
    {
        BeatScroller arrow = Instantiate(blueArrow,
            new Vector3(blueButton.transform.position.x, blueButton.transform.position.y + topScreen, 0), blueButton.transform.localRotation);
        arrow.BPM = this.bpm * scrollSpeed;
    }
}