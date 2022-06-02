using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerID;
    public int nextCheckpoint;
    public int lapNumber;
    public bool startedFirstLap;

    public float[] lapTimes;

    [Header("References")]
    public GameManager gameManager;
    public GameObject previousCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        lapTimes = new float[gameManager.totalLaps + 1];
    }

    // Update is called once per frame
    void Update()
    {
        lapTimes[0] += Time.deltaTime;
    }

    public void SetLapTime()
    {
        if (lapNumber <= gameManager.totalLaps)
        {
            // Set the lap time to be equal to the current lap time
            lapTimes[lapNumber] = lapTimes[0];

            // Reset the current lap time
            lapTimes[0] = 0;
        }

        else
        {
            Debug.Log("Lap Comleted but the race is over");
        }
    }
}
