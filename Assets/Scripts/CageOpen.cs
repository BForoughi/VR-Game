using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageOpen : MonoBehaviour
{
    public AudioClip cageOpen;
    private AudioSource audioSource;
    public Animator animator;
    public LeverBreak leverBreak;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
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
