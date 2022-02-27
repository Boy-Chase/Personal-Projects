using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // amount of health at start
    public int health = 3;

    // gotta be a more efficient method than bool swapping
    bool goalReached = false;
    bool goalNotReached = true;
    public int currentCheckpoint = 2;

    public bool onGround = false;

    public bool onWall = false;

    // wall info to pass to PlayerMovement
    public bool wallIsRight;

    // the level's goal
    public GameObject goal;

    // runs on collision
    void OnCollisionEnter(Collision objectHit)
    {
        // if you touch a goal
        if (objectHit.gameObject.GetComponent<Goal>() != null)
        {
            // starts next level load
            StartCoroutine(loadWait());
        }

        // used in PlayerMovement for jump check
        if (objectHit.gameObject.GetComponent<Ground>() != null)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        // used in PlayerMovement for wall run
        if (objectHit.gameObject.GetComponent<Wall>() != null)
        {
            onWall = true;
            wallIsRight = objectHit.gameObject.GetComponent<Wall>().right;
        }
        else
        {
            onWall = false;
        }

        // detects if collsion damage should be dealt to player
        if (objectHit.gameObject.GetComponent<Harmful>() != null)
        {
            // damage dealt
            health -= objectHit.gameObject.GetComponent<Harmful>().damage;

            // destroys obstacle
            Destroy(objectHit.gameObject);

            // game over if out of health
            if (health < 0)
            {
                SceneManager.LoadScene(2);
            }
        }

        if (goalReached)
        {
            if (goalNotReached)
            {
                goalNotReached = false;
                currentCheckpoint++;
                SceneManager.LoadScene(currentCheckpoint);
            }

        }
    }
    IEnumerator loadWait()
    {
        goalReached = true;

        yield return new WaitForSeconds(1f);
    }
}
