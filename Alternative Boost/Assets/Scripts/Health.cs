using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // amount of health at start
    public int health = 3;

    public bool onGround = false;

    public bool onWall = false;

    // runs on collision
    void OnCollisionEnter(Collision objectHit)
    {
        // used in PlayerMovement for jump check
        if (objectHit.gameObject.GetComponent<Ground>() != null)
        {
            onGround = true;
        }

        // used in PlayerMovement for wall run
        if (objectHit.gameObject.GetComponent<Wall>() != null)
        {
            onWall = true;
        }

        // detects if collsion damage should be dealt to player
        if (objectHit.gameObject.GetComponent<Harmful>() != null)
        {
            // damage dealt
            health -= objectHit.gameObject.GetComponent<Harmful>().damage;

            // destroys obstacle
            Destroy(objectHit.gameObject);
        }
    }
}
