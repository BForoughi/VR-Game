using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageOpen : MonoBehaviour
{
    public AudioClip CageOpen;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = getObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        openCageDoor();

    }
    private void openCageDoor()
    {
        audioSource.play();
    }
}
