using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour

{
    public int currentHealth;
    public int maxHealth = 5;


    public HealthDisplayScript healthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //healthDisplay.UpdateHealthDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

 

   public void TakeDamage()
    {
        currentHealth -= 1;
        Debug.Log("player has been hit");
    }

    void Die()
    {
        Debug.Log("player should be dead");
        //death screen
    }
}
