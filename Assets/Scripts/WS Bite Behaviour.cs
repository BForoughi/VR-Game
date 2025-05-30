using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using static UnityEngine.GraphicsBuffer;


public class WSBiteBehaviour : MonoBehaviour

{
    public EnemyStatus enemyStatus;
    public BiteBehaviour biteBehaviour;
    private bool trigger;


    private void Start()
    {
        enemyStatus = GetComponentInParent<EnemyStatus>();
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


    void Update()
    {
        if (biteBehaviour.bitten == true && trigger == true )
        {
            enemyStatus.takeDamage();
            biteBehaviour.bitten = false;
            Destroy(gameObject);
        }
    }
}
  
