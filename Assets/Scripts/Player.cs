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

    public float[] lapTimes;
    public float currentTime;
    public float totalLapsTime;
    public float countdownTimer = 4f;
    public bool isStarted = false;

    public string resetKey;

    [Header("References")]
    public GameObject previousCheckpoint;
    public UIManager ui;
    public Player thisPlayer;
    public Player otherPlayer;
    public Rigidbody playerRB;

    [HideInInspector] public PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        lapTimes = new float[GameManager.totalLaps + 1];
        thisPlayer = GetComponent<Player>();
        playerRB = otherPlayer.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown has finished
        if (isStarted)
        {
            lapTimes[0] += Time.deltaTime;
            currentTime += Time.deltaTime;

            if (Input.GetKeyDown(resetKey))
            {
                thisPlayer.transform.position = thisPlayer.previousCheckpoint.transform.position;
                thisPlayer.transform.rotation = thisPlayer.previousCheckpoint.transform.rotation;
                playerRB.velocity = playerRB.velocity.normalized * 0;
                Rigidbody carRigidbody = thisPlayer.GetComponent<Rigidbody>();
                carRigidbody.velocity = carRigidbody.velocity.normalized * 0;
            }
        }
        // Countdown starts
        else
        {
            countdownTimer -= Time.deltaTime;

            if (countdownTimer < 0)
            {
                isStarted = true;
                thisPlayer.GetComponent<SimpleCarController>().maxMotorTorque = (thisPlayer.GetComponent<SimpleCarController>().chosenCar.currentCar.speed * 215) + 2000;
            }
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


    }
}
