using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Health : MonoBehaviour
{
    public C_HealthData healthData;  
    private int currentHealth;
    private Coroutine healthRegenCoroutine;
    private C_lives playerLives;

    void Start()
    {
        currentHealth = healthData.maxHealth;
        healthRegenCoroutine = StartCoroutine(RegenerateHealth());
        playerLives = GetComponent<C_lives>();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            playerLives.DecreaseLives();
        }
    }

    private IEnumerator RegenerateHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(healthData.healthRegenInterval);

            if (currentHealth < healthData.maxHealth)
            {
                currentHealth += healthData.healthRegenAmount;
                if (currentHealth > healthData.maxHealth)
                {
                    currentHealth = healthData.maxHealth;
                }
            }
        }
    }

    private void Die()
    {
        Debug.Log("Player has died");
        playerLives.DecreaseLives();
    }

}
