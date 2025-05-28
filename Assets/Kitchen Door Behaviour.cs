using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoorBehavioour : MonoBehaviour
{
    public Animator animator;
    public CultistSpawnScript CultistSpawn;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (CultistSpawn.deathFlag == 1)
        {
            animator.SetBool("isOpen", true);
        }
        
    }
}
