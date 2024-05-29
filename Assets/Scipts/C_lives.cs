using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class C_lives : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;
    public TextMeshProUGUI textMeshPro; 

    void Start()
    {
        currentLives = maxLives;
        UpdateLivesUI(); 
    }


    public void DecreaseLives()
    {
        currentLives--;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            SceneManager.LoadScene("derrota");
        }
    }

    void UpdateLivesUI()
    {
        textMeshPro.text = $" {currentLives} " ;
    }

}
