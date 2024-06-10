using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Manager : MonoBehaviour
{

    public UnityEvent LoseLife;
    public UnityEvent PlayerDeath;
    public UnityEvent PlayerWasDamaged;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
