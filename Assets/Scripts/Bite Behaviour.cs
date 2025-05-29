using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using static UnityEngine.GraphicsBuffer;


public class BiteBehaviour : MonoBehaviour
{

    public SteamVR_Action_Boolean biteAction; //accesses the controllers input
    public bool jawCollision;
    public bool bitten;
    private bool hasBitten;

    public AudioSource audioSource;
    public AudioClip biteSound;


    public SphereCollider sphereCollider; //collider of the VR player head

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (biteAction.GetStateDown(SteamVR_Input_Sources.Any) && jawCollision == true) //is true when the bite button pressed and jaw collider is touching
        {
            bitten = true;
            Debug.Log("button is pressed and jaw is touching");
        }

        if (bitten && !hasBitten) //plays the sound after bite and resets it
        {
            playBiteSound();
            hasBitten = true;
        }

        if (!bitten)
        {
            hasBitten = false;
        }
        //if (biteAction.GetStateDown(SteamVR_Input_Sources.Any)){
        //    Debug.Log("Button is pressed");
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bitable"))
        {
            jawCollision = true;
            //Debug.Log("jaw is touching " + gameObject.name + " and " + other.gameObject.name + " Col? " + jawCollision);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Bitable"))
        {
            jawCollision = true;
            //Debug.Log("jaw is staying " + gameObject.name + " and " + other.gameObject.name + " Col? " + jawCollision);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bitable"))
        {
            jawCollision = false;
            //Debug.Log("Col false? " + jawCollision);
        }
    }
    private void playBiteSound()
    {
            audioSource.PlayOneShot(biteSound);
            Debug.Log("Bite sound played.");
    }

}