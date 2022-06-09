using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject playerUIPrefab;
    public GameObject parent;

    public Player[] players;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Player player in players)
        {
            PlayerUI newPlayerUI = Instantiate(playerUIPrefab, parent.transform).GetComponent<PlayerUI>();
            newPlayerUI.player = player;
            newPlayerUI.gameObject.name = newPlayerUI.player + "UI";
            player.playerUI = newPlayerUI;
        }
    }

    private void Update()
    {
        
    }
}
