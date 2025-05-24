using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoorBehavioour : MonoBehaviour
{
    public Animator animator;
    public EnemyStatus enemyStatus;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (enemyStatus.deathFlag == 3)
        {
            animator.SetBool("isOpen", true);
        }
        
    }
}
