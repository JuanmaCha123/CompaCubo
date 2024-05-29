using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_HealthBar : MonoBehaviour
{
    public Image healthBarImage; // Reference to the health bar image
    public C_Health playerHealth; // Reference to the PlayerHealth script

    void Start()
    {
        if (healthBarImage == null || playerHealth == null)
        {
            return;
        }
    }

    void Update()
    {
        if (healthBarImage != null && playerHealth != null)
        {
            // Update the health bar fill amount based on the player's current health
            healthBarImage.fillAmount = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        }
    }
}

