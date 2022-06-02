using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapTest : MonoBehaviour
{
    // Hi Vincent! Pls delete this comment
    public float currentLapTime;
    public float firstLapTime;
    public float secondLapTime;
    public float thirdLapTime;
    public float totalLapTime;

    bool startTimer = false;

    public bool checkpoint1 = false;
    public bool checkpoint2 = false;
    public bool checkpoint3 = false;

    public int lapNumber = 1;

    public TMP_Text timerText;
    public TMP_Text firstLapTimeText;
    public TMP_Text secondLapTimeText;
    public TMP_Text thirdLapTimeText;
    public TMP_Text totalLapTimeText;
    public TMP_Text lapNumberText;

    public float timerHoldNumber; // Unsure what else to call it

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lapNumberText.text = lapNumber + "/3";
        // if timer has started
        if (startTimer)
        {
            currentLapTime = currentLapTime + Time.deltaTime;

            timerText.text = currentLapTime.ToString("f2");
            //Debug.Log(lapTime);
        }

        if (lapNumber >= 3)
        {
            lapNumberText.text = 3 + "/3";
        }

        // if the startTimer hasn't started
        if (startTimer == false)
        {
            startTimer = true;

            checkpoint1 = false;
            checkpoint2 = false;
            checkpoint3 = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        // if the player passes through the finish line
        if (other.gameObject.name == "FinishLine")
        {
            // if the checkpoints have all been passed through once
            if (checkpoint1 == true && checkpoint2 == true && checkpoint3 == true)
            {
                lapNumber++;

                // Completed first lap
                if (lapNumber == 2)
                {
                    startTimer = false;
                    firstLapTime = currentLapTime;
                    firstLapTimeText.text = firstLapTime.ToString("f2");
                }

                // Completed second lap
                if (lapNumber == 3)
                {
                    startTimer = false;
                    secondLapTime = currentLapTime - firstLapTime;
                    secondLapTimeText.text = secondLapTime.ToString("f2");

                    timerHoldNumber = currentLapTime;
                }

                // Completed third lap
                if (lapNumber == 4)
                {
                    startTimer = false;
                    thirdLapTime = currentLapTime - timerHoldNumber;
                    thirdLapTimeText.text = thirdLapTime.ToString("f2");
                    totalLapTimeText.text = currentLapTime.ToString("f2");
                }

            }


        }

        if (other.gameObject.name == "checkpoint1")
        {
            checkpoint1 = true;
            Debug.Log("Checkpoint 1");
        }

        if (other.gameObject.name == "checkpoint2")
        {
            checkpoint2 = true;
            Debug.Log("Checkpoint 2");
        }

        if (other.gameObject.name == "checkpoint3")
        {
            checkpoint3 = true;
            Debug.Log("Checkpoint 3");
        }
    }
}
