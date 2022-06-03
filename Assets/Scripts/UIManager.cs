using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Values")]
    public TMP_Text gameTimer;
    public TMP_Text lapTimeText;
    public TMP_Text lapNumberText;
    
    [Header("References")]
    public Player player;
    public GameManager gameManager;
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameTimer.text = string.Format("{0:00}:{1:00}:{2:00}", timer.t_minutes, timer.t_seconds, timer.t_miliseconds);
        
        lapNumberText.text = player.lapNumber + "/" + gameManager.totalLaps;
    }
}
