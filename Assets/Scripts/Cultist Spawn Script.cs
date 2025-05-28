using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class CultistSpawnScript : MonoBehaviour
{
    
    public int deathFlag;
    public kitchenDoorOpen KitchenDoor;
    
    public GameObject cultistPrefab;
    public GameObject JawCollider;
    public GameObject Player;
    private Array WeakSpots;

    public bool case1Finish = false;
    public bool case2Finish = false;
    public bool case3Finish = false;
    public bool case4Finish = false;
    public bool case5Finish = false;
    public bool case6Finish = false;
    public bool case7Finish = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (deathFlag)
        { 
            case 0:
                if (!case2Finish)
                {
                    SpawnCultist();
                    case2Finish = true;
                }
                break;
            case 1:
                if (!case1Finish)
                {
                    SpawnCultist();
                    SpawnCultist();
                    KitchenDoor.openDoor();
                    case1Finish = true;
                }
                break;
            case 3:
                if (!case3Finish)
                {
                    KitchenDoor.openDoor();
                    case3Finish = true;
                }
                break;
            default:
                break;
        }
    }


    public void AddDeath()
    {
        deathFlag += 1;
        Debug.Log("Deathflag += 1");
    }
    void SpawnCultist()
    {
        
        GameObject newCultist = Instantiate(cultistPrefab);
        newCultist.GetComponent<EnemyStatus>().cultistSpawn = this;
        newCultist.GetComponent<BasicEnemyPatrol>().Player = Player.GetComponent<Transform>();
        WeakSpots = newCultist.GetComponentsInChildren<WSBiteBehaviour>();
        foreach(WSBiteBehaviour script in WeakSpots)
        {
            script.biteBehaviour = JawCollider.GetComponent<BiteBehaviour>();
        }

    }
}
