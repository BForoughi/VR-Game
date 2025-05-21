using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using static UnityEngine.GraphicsBuffer;


public class BiteBehaviour : MonoBehaviour
{

    public SteamVR_Action_Boolean biteAction; //accesses the controllers input
    private GameObject heldObject;
    private GameObject touchingObject;
    private bool bitten;

    public SphereCollider sphereCollider; //collider of the VR player head



    //void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

 

    void Update()
    {
        if (biteAction.GetStateDown(SteamVR_Input_Sources.Any)) //used to check if the button has been pressed
        {
            Debug.Log("Bite Button Pressed"); 
        }

        if (biteAction.GetStateDown(SteamVR_Input_Sources.Any) && touchingObject) 
        {
            Destroy(gameObject);
            Debug.Log("touching obj");
        }

        if (biteAction.GetStateDown(SteamVR_Input_Sources.Any) && bitten == true)
        {
            Destroy(gameObject);
            Debug.Log("bitten");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        touchingObject = other.gameObject;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Jaw") == true)
        {
            bitten = true;
        }
    }


    void Grab(GameObject obj)
    {
        heldObject = obj;
        obj.transform.SetParent(transform); //makes the object move with the jaw
    }

    void Release()
    {
        heldObject.transform.SetParent(null);
        heldObject = null;
    }


}
