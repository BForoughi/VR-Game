using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyFootsteps : MonoBehaviour
{
    public AudioClip[] Footsteps;
    private AudioSource audioSource;
    public float delay = 0.7f; //can be changed to match enemy speed
    float startingTime = 0f;
    public NavMeshAgent agent;

    public bool isMoving = true;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        //ChangeClip(1);
        agent = GetComponent<NavMeshAgent>();


        startingTime = Time.time;
    }


    

    // Update is called once per frame
    void Update()
    {

        isMoving = agent.velocity.magnitude > 0.1f; //detects movement

        if (isMoving)
        {
            if (Time.time > startingTime + delay) //plays footsteps after the delay time has passed
            {
                startingTime = Time.time;
                PlayFootsteps();
            }   
        }

       

        // plays audio if the enemy position moves
        //if (transform.position.x > oldPosition)
        //{
        //    PlayFootsteps();
        //}

        //if (transform.position.y > oldPosition)
        //{
        //    PlayFootsteps();
        //}
    }

   
    private void PlayFootsteps()
    {
        int randIndex = UnityEngine.Random.Range(0, Footsteps.Length); //creates a random number within the range of the number of audio clips
        audioSource.PlayOneShot(Footsteps[randIndex]); //plays one of the clips of that number

    }





    //private void ChangeClip(int num)
    //{

    //    audioSource.clip = Footsteps[num-1];

    //}
    

}
