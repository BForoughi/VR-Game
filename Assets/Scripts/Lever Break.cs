using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeverBreak : MonoBehaviour
{

    public BiteBehaviour biteBehaviour;
    public bool openDoor;
    private bool trigger;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jaw"))
        {
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Jaw"))
        {
            trigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (biteBehaviour.bitten == true && trigger == true)
        {
            Destroy(gameObject);
            openDoor = true;
            biteBehaviour.bitten = false;
        }
     
    }
}
