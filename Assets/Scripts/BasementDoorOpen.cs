using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoorOpen : MonoBehaviour
{
    public AudioClip openSound;
    public AudioSource audioSource;
    public Animator animator;
    //public CultistSpawnScript CultistSpawn;

    private bool doorOpened;

    public bool testDoor;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        //if (CultistSpawn.deathFlag == 1 && !doorOpened)
        //{
        //    playDoorOpenSound();
        //    doorOpened = true;
        //    animator.SetBool("isOpen", true);
        //}


        //if (CultistSpawn.deathFlag != 3)
        //{
        //    doorOpened = false;
        //}
    }
    
    // Update is called once per frame
   public void playDoorOpenSound()
    {
        audioSource.PlayOneShot(openSound);
        Debug.Log("basement Door sound is playing");
    }
   
    public void openDoor()
    {
        if (!doorOpened)
        {
            playDoorOpenSound();
            doorOpened = true;
            animator.SetBool("isOpen", true);
        }
    }
}
