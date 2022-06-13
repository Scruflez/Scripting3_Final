using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public int playerID;
    public int nextCheckpoint;
    public int lapNumber;
    public bool startedFirstLap;
    public bool finishedLastLap;
    public bool winner;
    public bool tie;

    public float[] lapTimes;
    public float currentTime;
    public float totalLapsTime;

    public string resetKey;

    [Header("References")]
    public GameObject previousCheckpoint;
    public UIManager ui;
    public Player thisPlayer;
    public Player otherPlayer;

    [HideInInspector] public PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        lapTimes = new float[GameManager.totalLaps + 1];
        thisPlayer = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        lapTimes[0] += Time.deltaTime;
        currentTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R))
        {
            thisPlayer.transform.position = thisPlayer.previousCheckpoint.transform.position;
        }
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
                // if this player has finished the last lap, and the other player hasn't
                if (finishedLastLap && otherPlayer.finishedLastLap == false)
                {
                    playerUI.SetPlayerEndTimeScreen(true);
                }

                else if (finishedLastLap && otherPlayer.finishedLastLap)
                {
                    totalLapsTime = lapTimes[1] + lapTimes[2] + lapTimes[3];

                    if (totalLapsTime < otherPlayer.totalLapsTime)
                    {
                        playerUI.SetPlayerEndTimeScreen(true);
                    }

                    else if (totalLapsTime > otherPlayer.totalLapsTime)
                    {
                        playerUI.SetPlayerEndTimeScreen(false);
                    }

                    else
                    {
                        playerUI.SetPlayerEndTimeScreen(true);
                    }
                }
            }
        }

        else
        {
            Debug.Log("Lap Comleted but the race is over");
        }
    }
}
