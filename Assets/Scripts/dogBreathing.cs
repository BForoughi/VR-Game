using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CheckBreathingSound : MonoBehaviour
{
    public AudioClip breathing;
    private AudioSource audioSource;
    private bool playing = true;

    public float delay = 23; 
    float startingTime = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = breathing;
        if (playing == true)
        {
            audioSource.PlayOneShot(breathing);
            playing = false;    
        }
        
        startingTime = Time.time;
    }

    void Update()
    {

        if (Time.time > startingTime + delay) //plays footsteps after the delay time has passed
        {
            startingTime = Time.time;
            playBreathing();
        }
    }

    void playBreathing()
    {
        audioSource.PlayOneShot(breathing);
        Debug.Log("Breathing sound is playing");
    }

}
