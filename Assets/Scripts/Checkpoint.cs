using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [HideInInspector]public Lap lap;
    public int order;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            Player player = other.GetComponent<Player>();

            // Check if this checkpoint is the next one the player is supposed to go through
            if (player.nextCheckpoint == order)
            {
                player.nextCheckpoint = lap.SetNextCheckpoint(order);

                player.previousCheckpoint = gameObject;
            
                if (order == 0)
                {
                    if (player.startedFirstLap)
                    {
                        player.lapNumber++;

                        player.SetLapTime();
                    }

                    else
                    {
                        player.startedFirstLap = true;
                        player.lapNumber++;
                    }
                }
            }

        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
