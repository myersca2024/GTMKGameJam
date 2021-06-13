using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public string filePath;
    public GameObject redEnemy;
    public GameObject blueEnemy;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private string[] keyframes;
    private int keyframeIndex = 0;
    private float bpm;
    private float currentTime = 0f;

    void Start()
    {
        keyframes = System.IO.File.ReadAllLines(@filePath);
        bpm = float.Parse(keyframes[keyframeIndex]);
        keyframeIndex++;
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
            for (int ii = 1; ii < keyframe.Length; ii+=3)
            {
                if (keyframe[ii] == "R")
                {
                    SpawnRedEnemy(float.Parse(keyframe[ii + 1]), float.Parse(keyframe[ii + 2]));
                }
                else if (keyframe[ii] == "B")
                {
                    SpawnBlueEnemy(float.Parse(keyframe[ii + 1]), float.Parse(keyframe[ii + 2]));
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

    void SpawnRedEnemy(float x, float y)
    {
        GameObject enemy = Instantiate(redEnemy, new Vector3(minX + x, minY + y, 0), redEnemy.transform.localRotation);
    }

    void SpawnBlueEnemy(float x, float y)
    {
        GameObject enemy = Instantiate(blueEnemy, new Vector3(minX + x, minY + y, 0), blueEnemy.transform.localRotation);
    }
}
