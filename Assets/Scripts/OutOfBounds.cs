using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public float timer;
    public bool timerRunning;

    public Player player;

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            timer -= Time.deltaTime;
            
            if (timer <= 0)
            {
                MovePlayer(player);

            }
        }

        else
        {
            timer = 3;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.GetComponent<Player>();

            timerRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timerRunning = false;
        }
        
    }

    private void MovePlayer(Player player)
    {
            player.transform.position = player.previousCheckpoint.transform.position;
    }
}
