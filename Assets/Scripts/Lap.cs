using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviour
{
    // Need code to reference both player laps and times
    public Checkpoint[] checkpoints;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].lap = this;
            checkpoints[i].order = i;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int SetNextCheckpoint(int currentCheckpoint)
    {
        // CHECK if we're at the end of the array
        if (currentCheckpoint + 1 >= checkpoints.Length)
        {
            return 0;
        }

        else
        {
            return currentCheckpoint + 1;
        }
    }
}
