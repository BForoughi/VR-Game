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
        audioSource.clip = breathing;
        audioSource.Play();
    }

    void Update()
    {
        // Check if audioSource is done playing
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            Debug.Log("Breathing sound restarted");
        }
    }
}
