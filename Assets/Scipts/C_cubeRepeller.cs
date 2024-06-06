using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_cubeRepeller : MonoBehaviour
{
    public Cube_ConfigData cubeConfig;

    private Transform playerTransform;
    private bool isCubeRepelled = false;
    private GameObject repelledCube;
    private int originalLayer;

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
        }

        if (isCubeRepelled && repelledCube != null)
        {
            Rigidbody2D rb = repelledCube.GetComponent<Rigidbody2D>();
            if (rb != null && rb.velocity.magnitude < cubeConfig.velocityThreshold)
            {
                ResetCubeLayer();
                isCubeRepelled = false;
                repelledCube = null;
            }
        }
    }

    void RepelCube()
    {
        Collider2D[] cubes = Physics2D.OverlapCircleAll(transform.position, cubeConfig.repulsionRadius, cubeConfig.cubeLayer);

        foreach (Collider2D cube in cubes)
        {
            if (!isCubeRepelled)
            {
                Vector3 repulsionDirection = (cube.transform.position - playerTransform.position).normalized;
                cube.GetComponent<Rigidbody2D>().AddForce(repulsionDirection * cubeConfig.repulsionForce, ForceMode2D.Impulse);
                repelledCube = cube.gameObject;
                originalLayer = repelledCube.layer;
                repelledCube.layer = LayerMask.NameToLayer("repelledCube");
                isCubeRepelled = true;
            }
        }
    }

    void ResetCubeLayer()
    {
        if (repelledCube != null)
        {
            repelledCube.layer = originalLayer;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, cubeConfig.repulsionRadius);
    }
}