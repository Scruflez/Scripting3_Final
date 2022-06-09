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
    public float totalLapTime;



    [Header("References")]
    public GameObject previousCheckpoint;
    public UIManager ui;
    public Player otherPlayer;

    [HideInInspector] public PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        lapTimes = new float[GameManager.totalLaps + 1];
    }

    // Update is called once per frame
    void Update()
    {
        lapTimes[0] += Time.deltaTime;
        totalLapTime += Time.deltaTime;
    }

    public void SetLapTime()
    {
        if (lapNumber <= GameManager.totalLaps)
        {
            // Set the lap time to be equal to the current lap time
            lapTimes[lapNumber] = lapTimes[0];

            // Reset the current lap time
            lapTimes[0] = 0;

            if (lapNumber == GameManager.totalLaps)
            {
                finishedLastLap = true;
                playerUI.SetPlayerEndTimeScreen();
            }
        }

        else
        {
            Debug.Log("Lap Comleted but the race is over");
        }
    }
}
