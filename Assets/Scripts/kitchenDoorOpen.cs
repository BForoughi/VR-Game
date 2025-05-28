using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenDoorOpen : MonoBehaviour
{
    public AudioClip openSound;
    private AudioSource audioSource;
    public Animator animator;
    public EnemyStatus enemyStatus;

    private bool doorOpened;

    public bool testDoor;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (enemyStatus.deathFlag == 3 && !doorOpened)
        {
            playDoorOpenSound();
            doorOpened = true;
            animator.SetBool("isOpen", true);
        }


        if (enemyStatus.deathFlag != 3)
        {
            doorOpened = false;
        }
    }
    
    // Update is called once per frame
   public void playDoorOpenSound()
    {
        audioSource.PlayOneShot(openSound);
        Debug.Log("Kitchen Door sound is playing");
    }
}
