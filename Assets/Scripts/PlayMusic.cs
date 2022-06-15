using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float timeBetweenLoops = 255f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenLoops)
        {
            audioSource.PlayOneShot(audioClip);
            timer = 0;
        }
    }
}
