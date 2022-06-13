using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text totalTime;
    public TMP_Text prevLapTime;
    public TMP_Text laps;
    public TMP_Text lap1Time;
    public TMP_Text lap2Time;
    public TMP_Text lap3Time;
    public TMP_Text totalLapTimeText;
    public TMP_Text placeText;

    public Player player;
    public GameObject playerEndTimeScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime.text = AsRaceTime(player.currentTime);
        laps.text = "Lap: " + (player.lapNumber + 1) + "/" + GameManager.totalLaps;

        if (player.lapNumber > 0)
        {
            prevLapTime.text = AsRaceTime(player.lapTimes[player.lapNumber]);
        }

        else if (player.lapNumber >= GameManager.totalLaps)
        {
            totalTime.text = " ";
            laps.text = " ";
        }
    }

    public void SetPlayerEndTimeScreen(bool winner, bool tie)
    {
        playerEndTimeScreen.SetActive(true);
        lap1Time.text = AsRaceTime(player.lapTimes[1]);
        lap2Time.text = AsRaceTime(player.lapTimes[2]);
        lap3Time.text = AsRaceTime(player.lapTimes[3]);
        totalLapTimeText.text = AsRaceTime(player.lapTimes[1] + player.lapTimes[2] + player.lapTimes[3]);

        if (winner)
        {
            placeText.text = "Winner!";
        }

        if (winner == false)
        {
            placeText.text = "Runner-Up!";
        }

    }

    public static string AsRaceTime(float seconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
        return timeSpan.ToString("mm':'ss':'ff");
    }
}
