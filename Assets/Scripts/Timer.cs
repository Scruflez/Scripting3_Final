using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float startTime;
    private float ellapsedTime;
    void Awake()
    {
        TimerStart();
    }
    // Update is called once per frame
    void Update()
    {
        ellapsedTime = Time.time - startTime;
    }
    void OnTriggerEnter()
    {
    }
    void TimerStart()
    {
        startTime = Time.time;
    }
    void OnGUI()
    {
        GUI.Label(new Rect(300, 100, 100, 20), (ellapsedTime.ToString()));
    }
}
