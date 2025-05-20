using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageOpen : MonoBehaviour
{
    public AudioClip cageOpen;
    private AudioSource audioSource;

    public bool testbutton = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (testbutton)
        {
            openCageDoor();
            testbutton = false;

        }
        

    }
    private void openCageDoor()
    {
        audioSource.PlayOneShot(cageOpen);

    }
}
