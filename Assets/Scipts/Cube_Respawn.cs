using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Respawn : MonoBehaviour
{
    private Camera mainCamera;
    private Transform playerTransform;
    private bool isOutOfBounds = false;
    private float outOfBoundsTime = 0f;
    public float respawnDelay = 3f;

    void Start()
    {
        mainCamera = Camera.main;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x < 0 || viewportPosition.x > 1 ||
            viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            if (!isOutOfBounds)
            {
                isOutOfBounds = true;
                outOfBoundsTime = Time.time;
            }
            else
            {
                if (Time.time - outOfBoundsTime >= respawnDelay)
                {
                    TeleportCube();
                }
            }
        }
        else
        {
            isOutOfBounds = false;
        }
    }

    void TeleportCube()
    {
        Vector3 newPosition = transform.position;

        float distanceX = Mathf.Abs(playerTransform.position.x - mainCamera.transform.position.x);
        float distanceY = Mathf.Abs(playerTransform.position.y - mainCamera.transform.position.y);

        if (playerTransform.position.x < mainCamera.transform.position.x)
        {
            newPosition.x = mainCamera.transform.position.x - distanceX / 2f;
        }
        else
        {
            newPosition.x = mainCamera.transform.position.x + distanceX / 2f;
        }
        if (playerTransform.position.y < mainCamera.transform.position.y)
        {
            newPosition.y = mainCamera.transform.position.y - distanceY / 2f;
        }
        else
        {
            newPosition.y = mainCamera.transform.position.y + distanceY / 2f;
        }

        transform.position = newPosition;
    }
}
