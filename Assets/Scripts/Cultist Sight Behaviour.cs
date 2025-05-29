using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistSightBehaviour : MonoBehaviour
{
    public BasicEnemyPatrol basicEnemyPatrol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enetered enemy sight range");
        if (other.CompareTag("Player")){
            basicEnemyPatrol.spotted = true;    
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("left enemy sight range");
        if (other.CompareTag("Player"))
        {
            basicEnemyPatrol.spotted = false;
        }
    }

}
