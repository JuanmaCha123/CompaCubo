using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_lives : MonoBehaviour
{
    public int maxLives = 3; // Máximo número de vidas
    public int currentLives; // Vidas actuales

    void Start()
    {
        currentLives = maxLives; // Configurar las vidas iniciales
    }

    public void DecreaseLives()
    {
        currentLives--; // Restar una vida

        if (currentLives <= 0)
        {
            
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
