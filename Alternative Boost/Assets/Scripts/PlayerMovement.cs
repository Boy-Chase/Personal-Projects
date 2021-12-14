using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    bool leftGo;
    bool rightGo;
    bool jumpGo;
    bool boostGo;

    // keyboard input
    private Vector2 playerInput;

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

        // button left movement
        if (leftGo)
        {
            GetComponent<Rigidbody>().AddForce(100f, 0f, 0f);
            leftGo = false;
        }
        // key left movement
        if (playerInput.x < 0)
        {
            GetComponent<Rigidbody>().AddForce(5f, 0f, 0f);
        }

        // button right movement
        if (rightGo)
        {
            GetComponent<Rigidbody>().AddForce(-100f, 0f, 0f);
            rightGo = false;
        }
        // key right movement
        if (0 < playerInput.x)
        {
            GetComponent<Rigidbody>().AddForce(-5f, 0f, 0f);
        }

        // button jump movement
        if (jumpGo)
        {
            if (gameObject.GetComponent<Health>().onGround)
            {
                GetComponent<Rigidbody>().AddForce(0f, 250f, 0f);
                gameObject.GetComponent<Health>().onGround = false;
                jumpGo = false;
            }
        }

        // key boost movement
        if (0 < playerInput.y)
        {
            boostGo = true;
        }
        // button boost movement
        if (boostGo)
        {
            StartCoroutine(boostWait());
        }

        // wall run
        if (gameObject.GetComponent<Health>().onWall)
        {
            // if hasn't been on wall for set frames
            if (wallRunCounter < 300)
            {
                // add force and increment
                GetComponent<Rigidbody>().AddForce(0f, 3.3f, 0f);
                wallRunCounter++;
            }
            // if at set frames
            if (wallRunCounter == 299)
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
    
    // called on ButtonLeft
    public void moveLeft()
    {
        leftGo = true;
    }

    // called on ButtonRight
    public void moveRight()
    {
        rightGo = true;
    }

    // called on ButtonJump
    public void jumpUp()
    {
        jumpGo = true;
    }

    // called on ButtonBoost
    public void boostForward()
    {
        boostGo = true;
    }

    IEnumerator boostWait()
    {
        GetComponent<Rigidbody>().AddForce(0f, 0f, -0.2f, ForceMode.Impulse);

        yield return new WaitForSeconds(1f);

        GetComponent<Rigidbody>().AddForce(0f, 0f, 0.2f, ForceMode.Impulse);
        boostGo = false;
    }

    // gets input
    public void OnMove(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }

    // key jump
    public void OnJumpNow(InputValue value)
    {
        jumpGo = true;
    }
}
