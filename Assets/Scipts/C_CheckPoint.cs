using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CheckPoint : MonoBehaviour
{
    private Vector3 currentCheckpoint;
    public C_HealthData healthData; 
    void Start()
    {
        currentCheckpoint = transform.position;

        if (healthData != null)
        {
            healthData.currentHealth = healthData.maxHealth;
        }
    }

    void Update()
    {
        if (healthData != null && healthData.currentHealth <= 0)
        {
            Respawn();
        }
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint;
        if (healthData != null)
        {
            healthData.currentHealth = healthData.maxHealth;
        }
    }
}

