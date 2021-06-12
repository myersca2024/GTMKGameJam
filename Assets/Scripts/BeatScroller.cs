using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float BPM;
    public bool hasStarted;

    private void Start()
    {
        BPM = BPM / 60f;
    }

    void Update()
    {
        transform.position -= new Vector3(0f, BPM * Time.deltaTime, 0f);
    }
}
