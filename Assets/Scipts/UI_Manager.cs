using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Manager : MonoBehaviour
{

<<<<<<< Updated upstream
    public UnityEvent LoseLife;
    public UnityEvent PlayerDeath;
    public UnityEvent PlayerWasDamaged;
=======
    public UnityEvent PlayerTookDamage;
    public UnityEvent PlayerLostLife;

>>>>>>> Stashed changes
    public static UI_Manager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(this.gameObject);
        }
    }
<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
=======
>>>>>>> Stashed changes
}
