using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_damage : MonoBehaviour
{
    public int damageAmount = 10; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.gameObject.CompareTag("Player"))
        {
            C_Health playerHealth = collision.gameObject.GetComponent<C_Health>();
            if (playerHealth != null)
            {
                collision.gameObject.GetComponent<C_Health>().damageAmount = damageAmount;
                UI_Manager.Instance.PlayerWasDamaged.Invoke();
            }
        }
    }
}
