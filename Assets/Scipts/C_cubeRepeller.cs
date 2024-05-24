using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_cubeRepeller : MonoBehaviour
{
    public float repulsionRadius = 5f;    
    public float repulsionForce = 10f;    
    public LayerMask cubeLayer;           

    private Transform playerTransform;    
    private bool isCubeRepelled = false;  
    private GameObject repelledCube;      

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isCubeRepelled)
            {
                RepelCube();
            }
            else
            {
                CancelRepulsion();
            }
        }
    }

    void RepelCube()
    {
        Collider2D[] cubes = Physics2D.OverlapCircleAll(transform.position, repulsionRadius, cubeLayer);

        foreach (Collider2D cube in cubes)
        {
            if (!isCubeRepelled)
            {
                Vector3 repulsionDirection = (cube.transform.position - playerTransform.position).normalized;
                cube.GetComponent<Rigidbody2D>().AddForce(repulsionDirection * repulsionForce, ForceMode2D.Impulse);
                repelledCube = cube.gameObject;
                isCubeRepelled = true;
            }
        }
    }

    void CancelRepulsion()
    {
        if (isCubeRepelled && repelledCube != null)
        {
            isCubeRepelled = false;
            repelledCube = null;
        }
    }

    // Para visualizar el radio de repulsión en la vista de escena
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, repulsionRadius);
    }
}
