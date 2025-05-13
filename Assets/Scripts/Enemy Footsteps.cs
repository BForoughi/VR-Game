using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFootsteps : MonoBehaviour
{
    public AudioClip[] Footsteps;
    public AudioSource audioSource;
    private float oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        ChangeClip(1);
    }

    void LateUpdate()
    {
        oldPosition = transform.position.x;
        oldPosition = transform.position.y;
    }



    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > oldPosition)
        {
            PlayFootsteps();
        }

        if (transform.position.y > oldPosition)
        {
            PlayFootsteps();
        }

        if (oldPosition == oldPosition)
        {
            audioSource.Stop();
        }
        //if (IsMoving())
        //{
        //    PlayFootsteps();
        //}


    }

    //private bool IsMoving()
    //{
    //    if (transform.position.x > oldPosition)
    //    {
    //        return true;
        
    //}

    private void PlayFootsteps()
    {

        audioSource.Play();
        
        //int clipIndex = Random.Range(0, Footsteps.Length);
        //audioSource.PlayOneShot(Footsteps[clipIndex]); 

    }
    private void ChangeClip(int num)
    {
        audioSource.clip = Footsteps[num-1];

    }
    private void StopFootsteps()
    {

        audioSource.Stop();

        

    }

}
