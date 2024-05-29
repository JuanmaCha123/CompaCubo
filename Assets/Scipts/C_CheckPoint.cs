using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CheckPoint : MonoBehaviour
{
    private Vector3 currentCheckpoint;
    private C_Health playerHealth;

    void Start()
    {
        playerHealth = GetComponent<C_Health>();
        currentCheckpoint = transform.position;

       
    }
    void Update()
    {
        if (playerHealth.currentHealth <= 0)
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
            playerHealth.currentHealth = playerHealth.maxHealth;
        }
   }

