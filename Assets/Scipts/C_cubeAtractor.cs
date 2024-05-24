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
    }

    void AttachCube()
    {
        Collider2D[] cubes = Physics2D.OverlapCircleAll(transform.position, attractionRadius, cubeLayer);

        foreach (Collider2D cube in cubes)
        {
            if (!isCubeAttached)
            {
                Vector3 newPosition = playerTransform.position + (transform.position - playerTransform.position).normalized * distanceFromPlayer;
                cube.transform.position = newPosition;
                attachedCube = cube.gameObject;
                isCubeAttached = true;
            }
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
