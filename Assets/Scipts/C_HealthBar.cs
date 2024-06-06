using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_HealthBar : MonoBehaviour
{
    public Image healthBarImage; // Referencia a la imagen de la barra de salud
    public C_HealthData playerHealthData; // Referencia al ScriptableObject C_HealthData

    void Start()
    {
        if (healthBarImage == null || playerHealthData == null)
        {
            Debug.LogError("Health bar image or player health data is not assigned.");
            return;
        }
    }

    void Update()
    {
        if (healthBarImage != null && playerHealthData != null)
        {
            // Actualizar la cantidad de relleno de la barra de salud basada en la salud actual del jugador
            healthBarImage.fillAmount = (float)playerHealthData.currentHealth / playerHealthData.maxHealth;
        }
    }
}

