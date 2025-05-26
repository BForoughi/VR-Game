using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour

{
    public int currentHealth;
    public int maxHealth = 5;

    public GameObject bodyCollider;

    public HealthDisplayScript healthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthDisplay.UpdateHealthDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))  
        {
            TakeDamage();
            healthDisplay.UpdateHealthDisplay();
        }
    }

    void TakeDamage()
    {
        currentHealth -= 1;
    }

    void Die()
    {
        //death screen
    }
}
