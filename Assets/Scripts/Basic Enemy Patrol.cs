using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyPatrol : MonoBehaviour
{

    public Vector3 destination; //where the enemy will go
    public Transform Player;
    //public Transform Patrol;
    public NavMeshAgent agent;
    //public GameObject indicator;
    public bool spotted; //determines whether the enemy can see the player
    public float searchTime;
    public float attackDelay = 12;
    public bool attackReady = false;

    public Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();

        //once player opens the cage, or enters the room
        //add patrol logic
        //animator.SetBool("isWalking", true);

        //spotted = false;
    }


    void Update()
    {
        if (spotted == false) //enemy will follow the patrol path
        {
            //indicator.SetActive(false);
            //destination = patrol.position;
            agent.destination = destination;
        }    
        if(spotted == true) //enemy will chase the player
        {
            //indicator.SetActive(true);
            destination = Player.position;
            agent.destination = destination;
        }

        if (attackReady == true)
        {
            animator.SetBool("isAttacking", true);
            Debug.Log("attacking");
            StartCoroutine(EndAttack());
        }
        
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        spotted = true;
    //    }
    //}
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(search());
        }
    }

    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        animator.SetBool("isAttacking", false);
    }
    IEnumerator search()
    {
        yield return new WaitForSeconds(searchTime);
        spotted = false;
    }

}
