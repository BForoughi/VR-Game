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


    private void Start()
    {
        enemyStatus = GetComponentInParent<EnemyStatus>();
    }



    void Update()
    {
        if (biteBehaviour.bitten == true)
        {
            enemyStatus.takeDamage();
        }
    }
}
  
