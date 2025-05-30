using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistAttackBehaviour : MonoBehaviour
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
            basicEnemyPatrol.attackReady = true;
            //Debug.Log("player in attack range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            basicEnemyPatrol.attackReady = false;
        }
    }

}
