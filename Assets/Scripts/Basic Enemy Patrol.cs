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
    public float attackDelay = 1;
    public bool attackReady = false;
    private float lastAttackTime = -Mathf.Infinity;
    public float attackCooldown = 1.5f; // or however long you want between attacks



    public Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (spotted == false) //enemy will follow the patrol path
        {
            //Debug.Log("player cant see you");

            if (!agent.pathPending && agent.remainingDistance < 1.5f) //distance between points
                {
                    Patrol();
                }
 
        }    
        if(spotted == true) //enemy will chase the player
        {
            //Debug.Log("player can see you");
            destination = Player.position;
            agent.destination = destination;
        }

        //if (attackReady == true)
        //{
        //    animator.SetBool("isAttacking", true);
        //    agent.speed = 0;
        //    //makes the enemy face the player when attacking
        //    Vector3 enemyDirection = Player.position - transform.position;
        //    enemyDirection.y = 0; 
        //    if (enemyDirection != Vector3.zero)
        //    {
        //        Quaternion targetRotation = Quaternion.LookRotation(enemyDirection);
        //        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        //    }

        //    StartCoroutine(EndAttack());
        //}

        if (attackReady && Time.time >= lastAttackTime + attackCooldown)
        {
            StartCoroutine(Attack());
            lastAttackTime = Time.time;
        }
    }

    IEnumerator Attack()
    {
        animator.SetBool("isAttacking", true);
        agent.speed = 0;

        // Look at player
        Vector3 enemyDirection = Player.position - transform.position;
        enemyDirection.y = 0;
        if (enemyDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(enemyDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }

        yield return new WaitForSeconds(0.5f); // Optional animation wind-up

        animator.SetBool("isAttacking", false);
        agent.speed = 3.5f; // Resume movement after attack
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
        Vector3 newDestination;

        // Try to get a destination that's at least 5 units away from current position
        int attempts = 0;
        do
        {
            newDestination = GetRandomNavMeshPoint(transform.position, patrolRadius);
            attempts++;
        }
        while (Vector3.Distance(transform.position, newDestination) < 100f && attempts < 10);

        destination = newDestination;
        agent.SetDestination(destination);
    }

    //void Patrol()
    //{
    //    destination = GetRandomNavMeshPoint(transform.position, patrolRadius);
    //    agent.SetDestination(destination);
    //}

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(search());
        }
    }

    //IEnumerator EndAttack()
    //{
    //    yield return new WaitForSeconds(attackDelay);
    //    animator.SetBool("isAttacking", false);
    //    agent.speed = 3.5f;
    //}
    IEnumerator search()
    {
        yield return new WaitForSeconds(searchTime);
        spotted = false;
    }

}
