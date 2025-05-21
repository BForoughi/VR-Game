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
    public bool jawCollision;

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

        //if (biteAction.GetStateDown(SteamVR_Input_Sources.Any) && touchingObject) 
        //{
        //    Destroy(gameObject);
        //    Debug.Log("touching obj");
        //}

        if (biteAction.GetStateDown(SteamVR_Input_Sources.Any) && jawCollision == true)
        {
            Destroy(gameObject);
            Debug.Log("bitten");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Jaw") == true)
        {
            jawCollision = true;
            Debug.Log("jaw is touching");
        }
        touchingObject = other.gameObject;
     
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Jaw") == true)
        {
            jawCollision = true;
            Debug.Log("jaw is touching");
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
