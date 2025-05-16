using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using static UnityEngine.GraphicsBuffer;


public class BiteBehaviour : MonoBehaviour
{

    public SteamVR_Action_Boolean input;
    public SphereCollider sphereCollider; //collider of the VR player head


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

    }
    private void OnCollisionEnter(Collision collision)
    {
        //if boxCollider.Comparetag("biteable")
        if (collision.gameObject.tag.Equals("Jaw") == true)
        {
            Destroy(this.gameObject);
        }
    }

}
