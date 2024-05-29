using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_damage : MonoBehaviour
{
    public int damageAmount = 10; // La cantidad de daño que el enemigo inflige al jugador

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el enemigo colisiona con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtener el componente PlayerHealth del jugador y aplicarle daño
            C_Health playerHealth = collision.gameObject.GetComponent<C_Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
