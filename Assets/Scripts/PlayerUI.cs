using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text totalTime;
    //public TMP_Text currentTime;
    public TMP_Text prevLapTime;
    public TMP_Text laps;
    public TMP_Text lap1Time;
    public TMP_Text lap2Time;
    public TMP_Text lap3Time;
    public TMP_Text totalLapTimeText;
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
        //currentTime.text = AsRaceTime(player.lapTimes[0]);
        laps.text = "Laps: " + (player.lapNumber + 1) + "/" + GameManager.totalLaps;

        if (player.lapNumber > 0)
        {
            prevLapTime.text = AsRaceTime(player.lapTimes[player.lapNumber]);
        }
    }

    public void SetPlayerEndTimeScreen()
    {
        playerEndTimeScreen.SetActive(true);
        lap1Time.text = AsRaceTime(player.lapTimes[1]);
        lap2Time.text = AsRaceTime(player.lapTimes[2]);
        lap3Time.text = AsRaceTime(player.lapTimes[3]);
        totalLapTimeText.text = AsRaceTime(player.lapTimes[1] + player.lapTimes[2] + player.lapTimes[3]);
    }

    public static string AsRaceTime(float seconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
        return timeSpan.ToString("mm':'ss':'ff");
    }
}
