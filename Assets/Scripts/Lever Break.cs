using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeverBreak : MonoBehaviour
{

    public BiteBehaviour biteBehaviour;
    public bool openDoor;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (biteBehaviour.bitten == true)
        {
            Destroy(gameObject);
            openDoor = true;
        }
     
    }
}
