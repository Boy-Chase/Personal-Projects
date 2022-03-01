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

    // stores input as a 2D vector
    private Vector2 playerInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        // otherwise nothing (neutral)
        else
        {
            manuever = 0;
        }

        // set for next frame comparison
        lastManuever = manuever;
    }

    
    public void action(int maneuverInt)
    {

    }

    // updates the input vector
    public void OnAction(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }
}
