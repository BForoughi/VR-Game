using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CheckBreathingSound : MonoBehaviour
{
    public AudioClip breathing;
    private AudioSource audioSource;
    private bool playing = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playing == true)
        {
            playBreathing();
            playing = false;    
        }  
    }

    void playBreathing()
    {
        audioSource.PlayOneShot(breathing);
        Debug.Log("Breathing sound is playing");
    }

}
