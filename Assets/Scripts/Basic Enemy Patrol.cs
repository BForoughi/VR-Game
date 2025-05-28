using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR.InteractionSystem;

public class BasicEnemyPatrol : MonoBehaviour
{

    public Vector3 destination; //where the enemy will go
    public Transform Player;
    public NavMeshAgent agent;
    public bool spotted; //determines whether the enemy can see the player
    public float patrolRadius = 100f;

    public float searchTime;
    public float attackDelay = 12;
    public bool attackReady = false;

    public Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        //add patrol logic

    }


    void Update()
    {
        if (spotted == false) //enemy will follow the patrol path
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                {
                    Patrol();
                }
 
           
            

        }    
        if(spotted == true) //enemy will chase the player
        {
            destination = Player.position;
            agent.destination = destination;
        }

        if (attackReady == true)
        {
            animator.SetBool("isAttacking", true);
            agent.speed = 0;
            Debug.Log("attacking");
            StartCoroutine(EndAttack());
        }
        
    }

    public Vector3 GetRandomNavMeshPoint(Vector3 center, float range)
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += center;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, range, NavMesh.AllAreas))
        {
            return hit.position;
        }

        // If no valid point found, return current position as fallback
        return center;
    }

    void Patrol()
    {
        destination = GetRandomNavMeshPoint(transform.position, patrolRadius);
        agent.SetDestination(destination);
    }

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
        agent.speed = 3.5f;
    }
    IEnumerator search()
    {
        yield return new WaitForSeconds(searchTime);
        spotted = false;
    }

}
