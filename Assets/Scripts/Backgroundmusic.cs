using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundmusic : MonoBehaviour
{
    private static Backgroundmusic instance = null;
    private AudioSource audio;

    // Start is called before the first frame update
    private void Awake()

    {
        if (instance == null)

            instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
