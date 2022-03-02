using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class charCon : MonoBehaviour
{
    // represents the current action of character
    // 0 = neutral
    // 1 = left dodge
    // 2 = right dodge
    // 3 = back step
    // 4 = attack (does nothing if meter too low)
    public int manuever = 0;

    // the previous input (used to check for change)
    public int lastManuever = 0;

    // amount of attack meter
    public int meter = 0;

    // timer for commitment to manuever
    public float timer = 0.0f;

    // stores input as a 2D vector
    private Vector2 playerInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TIMER

        // if timer is under a second
        if (timer < 1.0f)
        {
            // nullify input bc still in commitment
            playerInput = new Vector2(0.0f, 0.0f);
            
            // add to timer
            timer += Time.deltaTime;
        }

        // INPUT TO ACTION:

        // key a (left dodge)
        if (playerInput.x < 0)
        {
            manuever = 1;
            gameObject.transform.position = new Vector3(-0.35f, 0.0f, 0.0f);
        }

        // key d (right dodge)
        else if (0 < playerInput.x)
        {
            manuever = 2;
            gameObject.transform.position = new Vector3(0.35f, 0.0f, 0.0f);
        }

        // key s (back step)
        else if (playerInput.y < 0)
        {
            manuever = 3;
            gameObject.transform.position = new Vector3(0.0f, -0.1f , -0.3f);
        }

        // key space (attack)
        else if (0 < playerInput.y)
        {
            manuever = 4;
            gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.2f);
        }

        // if pose changes, start timer to begin commit 
        if (manuever != lastManuever)
        {
            timer = 0.0f;
        }

        // no input (neutral)
        if (1.0f <= timer)
        {
            manuever = 0;
            gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }

        // set for next frame comparison
        lastManuever = manuever;
    }

    // updates the input vector
    public void OnAction(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }
}