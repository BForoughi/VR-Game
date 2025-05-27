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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")){
            basicEnemyPatrol.spotted = true;    
        }
    }

}
