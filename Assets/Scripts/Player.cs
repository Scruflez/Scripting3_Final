using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerID;
    public int nextCheckpoint;
    public int lapNumber;
    public bool startedFirstLap;
    public bool finishedLastLap;

    public float[] lapTimes;
    public int t_minutes;
    public int t_seconds;
    public int t_miliseconds;

    public int t_minutes1;
    public int t_seconds1;
    public int t_miliseconds1;

    public int t_minutes2;
    public int t_seconds2;
    public int t_miliseconds2;

    public int t_minutes3;
    public int t_seconds3;
    public int t_miliseconds3;

    public float totalLapTime;
    public int t_minutesTotal;
    public int t_secondsTotal;
    public int t_milisecondsTotal;



    [Header("References")]
    public GameManager gameManager;
    public GameObject previousCheckpoint;
    public UIManager ui;
    public Player otherPlayer;

    // Start is called before the first frame update
    void Start()
    {
        lapTimes = new float[gameManager.totalLaps + 1];
    }

    // Update is called once per frame
    void Update()
    {
        lapTimes[0] += Time.deltaTime;

        /*
        t_minutes1 = ((int)lapTimes[1] / 60); // t(seconds0 / 60 = total minutes
        t_seconds1 = ((int)lapTimes[1] % 60); // t(seconds) % 60 = total seconds
        t_miliseconds1 = ((int)(lapTimes[1] * 100)) % 100; // (total seconds * 1000) % 1000 = total miliseconds;

        t_minutes2 = ((int)lapTimes[2] / 60); // t(seconds0 / 60 = total minutes
        t_seconds2 = ((int)lapTimes[2] % 60); // t(seconds) % 60 = total seconds
        t_miliseconds2 = ((int)(lapTimes[2] * 100)) % 100; // (total seconds * 1000) % 1000 = total miliseconds;

        t_minutes3 = ((int)lapTimes[3] / 60); // t(seconds0 / 60 = total minutes
        t_seconds3 = ((int)lapTimes[3] % 60); // t(seconds) % 60 = total seconds
        t_miliseconds3 = ((int)(lapTimes[3] * 100)) % 100; // (total seconds * 1000) % 1000 = total miliseconds;

        totalLapTime = lapTimes[1] + lapTimes[2] + lapTimes[3];
        t_minutesTotal = ((int)totalLapTime / 60);  // t(seconds0 / 60 = total minutes
        t_secondsTotal = ((int)totalLapTime % 60); // t(seconds) % 60 = total seconds
        t_milisecondsTotal = ((int)(totalLapTime * 100)) % 100; // (total seconds * 1000) % 1000 = total miliseconds;
        */
    }

    public void SetLapTime()
    {
        if (lapNumber <= gameManager.totalLaps)
        {
            // Set the lap time to be equal to the current lap time
            lapTimes[lapNumber] = lapTimes[0];

            /*
            t_minutes = ((int)lapTimes[lapNumber] / 60); // t(seconds0 / 60 = total minutes
            t_seconds = ((int)lapTimes[lapNumber] % 60); // t(seconds) % 60 = total seconds
            t_miliseconds = ((int)(lapTimes[lapNumber] * 100)) % 100; // (total seconds * 1000) % 1000 = total miliseconds;
            */

            //ui.DisplayLapTime();

            // Reset the current lap time
            lapTimes[0] = 0;

            if (lapNumber == gameManager.totalLaps)
            {
                finishedLastLap = true;
                //ui.WinScreenScore();
            }
        }

        else
        {
            Debug.Log("Lap Comleted but the race is over");
        }
    }
}
