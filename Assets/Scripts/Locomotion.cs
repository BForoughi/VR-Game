using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Locomotion : MonoBehaviour
{

    public SteamVR_Action_Vector2 input;
    [Range(0, 10)]
    public float speed = 1;
    public CharacterController CharCon;
    public bool HeadLoco = true;



    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        CharCon = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction;
        if (HeadLoco)
        { //head 
            direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));     
        }
        else
        { //central
            direction = Player.instance.transform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));     
        }
        CharCon.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0,9.81f,0) * Time.deltaTime);
    }
}
