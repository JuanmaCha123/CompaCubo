using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_cubeAtractor : MonoBehaviour
{
    public float attractionRadius = 5f;
    public LayerMask cubeLayer;
    public float distanceFromPlayer = 0.2f;

    private Transform playerTransform;
    private bool isCubeAttached = false;
    private GameObject attachedCube;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isCubeAttached)
            {
                AttachCube();
            }
            else
            {
                DetachCube();
            }
        }

        if (isCubeAttached && attachedCube != null)
        {
            
            float direction = playerTransform.localScale.x; 
            attachedCube.transform.position = playerTransform.position + new Vector3(direction * distanceFromPlayer, 0, 0);
        }
    }

    void AttachCube()
    {
        Collider2D[] cubes = Physics2D.OverlapCircleAll(playerTransform.position, attractionRadius, cubeLayer);

        if (cubes.Length > 0)
        {
            Collider2D cube = cubes[0]; 
            attachedCube = cube.gameObject;
            isCubeAttached = true;

            float direction = playerTransform.localScale.x; 
            Vector3 newPosition = playerTransform.position + new Vector3(direction * distanceFromPlayer, 0, 0);
            attachedCube.transform.position = newPosition;
        }
    }

    void DetachCube()
    {
        if (isCubeAttached && attachedCube != null)
        {
            isCubeAttached = false;
            attachedCube = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attractionRadius);
    }
}
