using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform_Elevator : MonoBehaviour
{
    public Transform elevator;
    public float elevatorSpeed = 2f;
    public Transform topPosition;
    public Transform bottomPosition;
    public LayerMask cubeLayer;

    private bool isCubeOnPlate = false;

    void Update()
    {
        MoveElevator();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & cubeLayer) != 0)
        {
            isCubeOnPlate = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & cubeLayer) != 0)
        {
            isCubeOnPlate = false;
        }
    }

    void MoveElevator()
    {
        if (isCubeOnPlate)
        {
            elevator.position = Vector2.MoveTowards(elevator.position, bottomPosition.position, elevatorSpeed * Time.deltaTime);
        }
        else
        {
            elevator.position = Vector2.MoveTowards(elevator.position, topPosition.position, elevatorSpeed * Time.deltaTime);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
        Gizmos.DrawLine(topPosition.position, bottomPosition.position);
    }
}
