using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Collisions : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.layer == LayerMask.NameToLayer("repelledCube"))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("door"))
            {
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
