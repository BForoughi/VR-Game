using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyStatus : MonoBehaviour
{
    public int maxHealth = 2;
    public int currentHealth;

    public int deathFlag;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 )
        {
            die();
        }
    }

    public void takeDamage()
    {
        currentHealth -= 1;
        if (currentHealth <= 0)
        {
            die();
        }
    }

    void die()
        {
            Destroy(gameObject);
            deathFlag += 1; //adds to the dead enemy counter
        }
}
