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
        //left movement
        if (leftGo)
        {
            // transform.Translate(1f, 0f, 0f);
            GetComponent<Rigidbody>().AddForce(25f, 0f, 0f);
            leftGo = false;
        }

        //right movement
        if (rightGo)
        {
            // transform.Translate(-1f, 0, 0);
            GetComponent<Rigidbody>().AddForce(-25f, 0f, 0f);
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
            GetComponent<Rigidbody>().AddForce(0f, 1.05f, 0f);
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
