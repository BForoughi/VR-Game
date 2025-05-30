using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageOpen : MonoBehaviour
{
    public AudioClip cageOpen;
    private AudioSource audioSource;
    public Animator animator;
    public LeverBreak leverBreak;


  
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (cageOpen == null)
        {
            Debug.LogWarning("CageOpen clip not set");
        }
    }


    

    // Update is called once per frame
    void Update()
    {

        if (leverBreak.openDoor == true)
        {
            openCageDoor();
            leverBreak.openDoor = false;
        }
        
    }
    private void openCageDoor()
    {
        animator.SetBool("isOpen", true);
        audioSource.PlayOneShot(cageOpen);
        Debug.Log("playing cage sound");
    }
}
