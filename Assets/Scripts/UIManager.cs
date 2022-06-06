using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Values")]
    public TMP_Text gameTimer;
    public TMP_Text lapNumberText;
    public TMP_Text lapTimeText;
    public TMP_Text firstLapTimeText; // Currently unable to add TMP objects depending on how many laps there are. Since the assignment only requires 3 laps, this will do for now
    public TMP_Text secondLapTimeText;
    public TMP_Text thirdLapTimeText;
    public TMP_Text totalLapTimeText;
    
    [Header("References")]
    public Player playerThis;
    public Player playerOther;
    public GameManager gameManager;
    public Timer timer;
    public GameObject playerUI;
    public GameObject winScreen;
    public TMP_Text resultText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameTimer.text = string.Format("{0:00}:{1:00}:{2:00}", timer.t_minutes, timer.t_seconds, timer.t_miliseconds);
        
        lapNumberText.text = playerThis.lapNumber + "/" + gameManager.totalLaps;
    }

    public void DisplayLapTime()
    {
        //lapTimeText = gameObject.AddComponent<TextMeshPro>();

        lapTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", playerThis.t_minutes, playerThis.t_seconds, playerThis.t_miliseconds);
    }

    public void WinScreenScore()
    {
        playerUI.SetActive(false);
        winScreen.SetActive(true);
        firstLapTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", playerThis.t_minutes1, playerThis.t_seconds1, playerThis.t_miliseconds1);
        secondLapTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", playerThis.t_minutes2, playerThis.t_seconds2, playerThis.t_miliseconds2);
        thirdLapTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", playerThis.t_minutes3, playerThis.t_seconds3, playerThis.t_miliseconds3);
        totalLapTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", playerThis.t_minutesTotal, playerThis.t_secondsTotal, playerThis.t_milisecondsTotal);

        if (playerThis.totalLapTime < playerOther.totalLapTime)
        {
            resultText.text = "Winner!";
        }

        else if (playerThis.totalLapTime == playerOther.totalLapTime)
        {
            resultText.text = "Tie!";
        }

        else
        {
            resultText.text = "Runner-Up!";
        }
    }
}
