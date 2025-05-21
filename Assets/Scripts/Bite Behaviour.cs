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
    private GameObject heldObject;
    private GameObject touchingObject;
    private bool jawCollision;
    public bool openDoor;

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

        if (biteAction.GetStateDown(SteamVR_Input_Sources.Any) && jawCollision == true)
        {
            Destroy(gameObject);
            openDoor = true;
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

    void OnTriggerExit(Collider other)
    {
        jawCollision = false;
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

