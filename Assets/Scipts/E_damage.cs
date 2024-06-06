using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_damage : MonoBehaviour
{
    public int damageAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            C_Health playerHealthData = collision.gameObject.GetComponent<C_Health>();
            if (playerHealthData != null)
            {
                playerHealthData.TakeDamage(damageAmount);
            }
        }
    }
}
