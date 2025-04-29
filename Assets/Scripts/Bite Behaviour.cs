using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class BiteBehaviour : MonoBehaviour
{

    public SteamVR_Action_Boolean input;
    public BoxCollider boxCollider;
    public SphereCollider sphereCollider;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     if boxCollider.Comparetag("biteable")
        {

        }    
    }
}
