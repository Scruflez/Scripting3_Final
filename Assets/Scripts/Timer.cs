using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int t_minutes;
    public int t_seconds;
    public int t_miliseconds;
    public float t;

    //private bool countDownRunning;
    float countdown = 4;

    private void Start()
    {
        //countDownRunning = true;
    }

    private void Update()
    {
        //if (countDownRunning)
        //{
        //    t = 0;
        //    countdown -= Time.deltaTime;

        //    if (countdown <= 0)
        //    {
        //        countDownRunning = false;
        //    }
        //}

        //else
        //{
            t += Time.deltaTime;

            t_minutes = ((int)t / 60); // t(seconds0 / 60 = total minutes
            t_seconds = ((int)t % 60); // t(seconds) % 60 = total seconds
            t_miliseconds = ((int)(t * 100)) % 100; // (total seconds * 1000) % 1000 = total miliseconds;
        //}
    }
}
