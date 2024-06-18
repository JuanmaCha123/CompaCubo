using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Health : MonoBehaviour
{
    public C_HealthData healthData;  
    private int currentHealth;
    private Coroutine healthRegenCoroutine;
    private C_lives playerLives;
    public int damageAmount;

    void Start()
    {
        currentHealth = healthData.maxHealth;
        healthRegenCoroutine = StartCoroutine(RegenerateHealth());
        playerLives = GetComponent<C_lives>();
    }

    public void TakeDamage()
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            UI_Manager.Instance.PlayerDeath.Invoke();
        }
        UI_Manager.Instance.PlayerTookDamage.Invoke();
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

    public void Die()
    {
        Debug.Log("Player has died");
        UI_Manager.Instance.LoseLife.Invoke();
    }

}
