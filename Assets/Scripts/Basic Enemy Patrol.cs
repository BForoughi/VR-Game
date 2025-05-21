using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyPatrol : MonoBehaviour
{

    public Vector3 destination; //where the enemy will go
    //public Transform Player, patrol; 
    public NavMeshAgent agent;
    public GameObject indicator;
    public bool spotted; //determines whether the enemy can see the player
    public float searchTime;

    public Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();

        //once player opens the cage, or enters the room
        animator.SetBool("isPatrolling", true);
        //spotted = false;
    }


    void Update()
    {
        if (spotted == false) //enemy will follow the patrol path
        {
            indicator.SetActive(false); 
            //destination = patrol.position;
            //agent.destination = destination;
        }    
        if(spotted == true) //enemy will chase the player
        {
            indicator.SetActive(true);
            //destination = Player.position;
            //agent.destination = destination;    
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spotted = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(search());
        }
    }
    IEnumerator search()
    {
        yield return new WaitForSeconds(searchTime);
        spotted = false;
    }

}
