using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HealthDisplayScript : MonoBehaviour
{
    public TextMeshProUGUI healthDisplay;
    public PlayerHealthController playerHealth;

    public void UpdateHealthDisplay()
    {
        healthDisplay.text = "Health: " + playerHealth.currentHealth;
    }


}
