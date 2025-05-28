using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour

{
    public int currentHealth;
    public int maxHealth = 5;


    public GameObject canvasPrefab;   
    public GameObject panelPrefab;

    public bool hasDied = false;

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
        if (!hasDied) //only calls the function once
        {
            Debug.Log("death screen");
            DeathScreen();
            hasDied = true;
        }
    }

    void DeathScreen()
    {
        Camera vrCamera = Camera.main;
        if (vrCamera == null)
        {
            Debug.LogError("MainCamera not found. Make sure your VR camera has the 'MainCamera' tag.");
            return;
        }

        GameObject canvasInstance = Instantiate(canvasPrefab);
        Canvas canvasComponent = canvasInstance.GetComponent<Canvas>();
        if (canvasComponent.renderMode == RenderMode.WorldSpace)
        {
            canvasComponent.worldCamera = vrCamera;
        }
        GameObject panelInstance = Instantiate(panelPrefab, canvasInstance.transform, false);
    }

}
