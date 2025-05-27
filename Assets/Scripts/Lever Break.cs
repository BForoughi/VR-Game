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
            Debug.Log("lever is touching the jaw");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Jaw"))
        {
            trigger = false;
            Debug.Log("lever is no longer touching");
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
            Debug.Log("lever is broken");
        }
     
    }
}
