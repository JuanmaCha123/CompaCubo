using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_movement : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed = 2f;

    private Vector3 leftPos;
    private Vector3 rightPos;
    private bool movingRight = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftPos = leftPoint.position;
        rightPos = rightPoint.position;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (transform.position.x >= rightPos.x)
            {
                movingRight = false;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (transform.position.x <= leftPos.x)
            {
                movingRight = true;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
