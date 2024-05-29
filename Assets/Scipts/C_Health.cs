using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int healthRegenAmount = 2;
    public float healthRegenInterval = 1f;

    private Coroutine healthRegenCoroutine;
    private C_lives playerLives;

    void Start()
    {
        currentHealth = maxHealth;
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
            yield return new WaitForSeconds(healthRegenInterval);

            if (currentHealth < maxHealth)
            {
                currentHealth += healthRegenAmount;
                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
            }
        }
    }


}
