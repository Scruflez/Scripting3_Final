using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("Timer and Lap Records")]
    float currentlapTime;
    float totalLapTime;
    float totalRaceTime;
    float elapsedTime;
    public TMP_Text totalTimeText;
    public GameObject checkpoint;

    public void Start()
    {
        //Getting the timer going
        elapsedTime = Time.time;
        
    }

    public void Update()
    {
        //starting the timer and displaying it
        float t = Time.time - elapsedTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        totalTimeText.text = minutes + ":" + seconds;

        if (true)
        {

        }
    }

    //Checkpoint recording lap time
    public void CheckpointReached()
    {

    }



}
