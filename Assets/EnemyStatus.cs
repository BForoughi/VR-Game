using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStatus : MonoBehaviour
{
    public int maxHealth = 2;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void takeDamage()
    {
        currentHealth -= 1;
        if (currentHealth < 1)
        {
            die();
        }
    }

    void die()
        {
            Destroy(gameObject);
        }
}
