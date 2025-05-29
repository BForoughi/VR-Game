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

    public Transform[] spawnPoints;
    private int spawnIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    //public Transform spawnPoint1;

    // Update is called once per frame
    void Update()
    {
        switch (deathFlag)
        { 
            case 0:
                if (!case2Finish)
                {
                    SpawnCultist(0);
                    
                    case2Finish = true;
                }
                break;
            case 1:
                if (!case1Finish)
                {
                    KitchenDoor.openDoor();
                    SpawnCultist(2);
                    SpawnCultist(3);
                    SpawnCultist(4);
                    case1Finish = true;
                }
                break;
            case 4:
                if (!case3Finish)
                {
                    SpawnCultist(5);
                    SpawnCultist(6);
                    SpawnCultist(7);
                    case3Finish = true;
                }
                break;
            case 7:
                if (!case4Finish)
                {
                    SpawnCultist(8);
                    SpawnCultist(9);
                    SpawnCultist(10);
                    case4Finish = true;
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
    void SpawnCultist(int x)
    {
        Transform spawnTransform = spawnPoints[x];
        GameObject newCultist = Instantiate(cultistPrefab, spawnTransform.position, spawnTransform.rotation);
        newCultist.GetComponent<EnemyStatus>().cultistSpawn = this;
        newCultist.GetComponent<BasicEnemyPatrol>().Player = Player.GetComponent<Transform>();
        WeakSpots = newCultist.GetComponentsInChildren<WSBiteBehaviour>();

        foreach(WSBiteBehaviour script in WeakSpots)
        {
            script.biteBehaviour = JawCollider.GetComponent<BiteBehaviour>();
        }

    }
}
