using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool leftGo;
    bool rightGo;
    bool jumpGo;
    bool boostGo;

    // keep track of how long wall run has been going
    public int wallRunCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        //set all to false at start of game
        leftGo = false;
        rightGo = false;
        jumpGo = false;
        boostGo = false;
    }

    // Update is called once per frame
    void Update()
    {
        // refreshes wall run if onGround but not onWall
        if (gameObject.GetComponent<Health>().onGround && !gameObject.GetComponent<Health>().onWall)
        {
            wallRunCounter = 0;
        }

        //left movement
        if (leftGo)
        {
            // transform.Translate(1f, 0f, 0f);
            GetComponent<Rigidbody>().AddForce(35f, 0f, 0f);
            leftGo = false;
        }

        //right movement
        if (rightGo)
        {
            // transform.Translate(-1f, 0, 0);
            GetComponent<Rigidbody>().AddForce(-35f, 0f, 0f);
            rightGo = false;
        }

        //jump movement
        if (jumpGo)
        {
            if (gameObject.GetComponent<Health>().onGround)
            {
                GetComponent<Rigidbody>().AddForce(0f, 250f, 0f);
                gameObject.GetComponent<Health>().onGround = false;
                jumpGo = false;
            }
        }

        //boost movement
        if (boostGo)
        {
            StartCoroutine(boostWait());
        }

        // wall run
        if (gameObject.GetComponent<Health>().onWall)
        {
            // if hasn't been on wall for set frames
            if (wallRunCounter < 400)
            {
                // add force and increment
                GetComponent<Rigidbody>().AddForce(0f, 2.0f, 0f);
                wallRunCounter++;
            }
            // if at set frames
            if (wallRunCounter == 399)
            {
                // wall is on right
                if (gameObject.GetComponent<Health>().wallIsRight)
                {
                    // pop off wall
                    GetComponent<Rigidbody>().AddForce(70f, 0f, 0f);
                }
                // wall is on left
                else
                {
                    // pop off wall
                    GetComponent<Rigidbody>().AddForce(-70f, 0f, 0f);
                }
            }
        }
    }
    
    //called on ButtonLeft
    public void moveLeft()
    {
        leftGo = true;
    }

    //called on ButtonRight
    public void moveRight()
    {
        rightGo = true;
    }

    //called on ButtonJump
    public void jumpUp()
    {
        jumpGo = true;
    }

    //called on ButtonBoost
    public void boostForward()
    {
        boostGo = true;
    }

    IEnumerator boostWait()
    {
        GetComponent<Rigidbody>().AddForce(0f, 0f, -0.1f, ForceMode.Impulse);

        yield return new WaitForSeconds(1f);

        GetComponent<Rigidbody>().AddForce(0f, 0f, 0.1f, ForceMode.Impulse);
        boostGo = false;
    }
}
