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


    public SphereCollider sphereCollider; //collider of the VR player head


    void Update()
    {
        //if (biteAction.GetStateDown(SteamVR_Input_Sources.Any)) //used to check if the button has been pressed
        //{
        //    Debug.Log("Bite Button Pressed");
        //}

        if (biteAction.GetStateDown(SteamVR_Input_Sources.Any) && jawCollision == true)
        {
            bitten = true;
            //call audio function
        }

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



    //audio function






}

