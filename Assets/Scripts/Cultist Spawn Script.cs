using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistSpawnScript : MonoBehaviour
{

    public EnemyStatus enemyStatus;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyStatus.deathFlag == 1) //function calls upon a cultists death
        {
            SpawnCultist();
        }
    }


    void SpawnCultist()
    {
        //GameObject newCultist = Instantiate(cultistPrefab);
        //newCultist.GetComponent<BasicEnemyPatrol>().agent.NavMeshAgentRef;
        //newCultist.GetComponent<BasicEnemyPatrol>().animator.animatorRef;
    }
}
