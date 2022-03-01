using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    // represents the current action of character
    // 0 = neutral
    // 1 = left attack
    // 2 = right attack
    // 3 = sweep attack
    public int manuever = 0;

    // the previous input (used to check for change)
    public int lastManuever = 0;
     

    // timer for commitment to manuever
    public float timer = 0.0f;

    // stores input as a 2D vector
    private Vector2 playerInput;

    // every 3 seconds
    public float threeSec = 0.0f;

    // odds of enemy moving
    public float actionChance;

    // has three second action been rolled
    bool threeSecAttempt = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // add to timer if it hasn't been three seconds 
        threeSec += Time.deltaTime;
        

        // maybe do something
        if (3.0f <= threeSec && !threeSecAttempt)
        {
            // tried three sec attempt
            threeSecAttempt = true;

            // roll to maybe do something
            actionChance = Random.Range(0.0f, 1.0f);

            // do something
            if (0.20f < actionChance)
            {
                // reset action cooldown
                threeSec = 0.0f;

                // we can try to do something in three seconds
                threeSecAttempt = false;

                // attack left
                if (actionChance < 0.50f)
                {
                    manuever = 2;
                    gameObject.transform.position = new Vector3(-0.35f, 1.0f, 1.0f);
                }

                // attack right
                else if (0.51f < actionChance && actionChance < 0.80f)
                {
                    manuever = 2;
                    gameObject.transform.position = new Vector3(0.35f, 1.0f, 1.0f);
                }

                // attack sweep
                else
                {
                    manuever = 2;
                    gameObject.transform.position = new Vector3(0.0f, 0.8f, 0.7f);
                }
            }

            // should we ever get to five seconds, definetly do an action
            if (5.0f < threeSec)
            {
                // reset action cooldown
                threeSec = 0.0f;

                // we can try to do something in three seconds
                threeSecAttempt = false;

                // attack left
                if (actionChance < 0.35f)
                {
                    manuever = 2;
                    gameObject.transform.position = new Vector3(-0.35f, 1.0f, 1.0f);
                }

                // attack right
                else if (0.36f < actionChance && actionChance < 0.70f)
                {
                    manuever = 2;
                    gameObject.transform.position = new Vector3(0.35f, 1.0f, 1.0f);
                }

                // attack sweep
                else
                {
                    manuever = 2;
                    gameObject.transform.position = new Vector3(0.0f, 1.0f, 0.7f);
                }
            }
        }

        /*

        // TIMER

        // if timer is under a second
        if (timer < 1.0f)
        {
            // nullify input bc still in commitment
            playerInput = new Vector2(0.0f, 0.0f);

            // add to timer
            timer += Time.deltaTime;

            // tried three sec attempt
            threeSecAttempt = true;

            // roll to maybe do something
            actionChance = Random.Range(0.0f, 1.0f);

            // do something
            if (0.20f < actionChance)
            {
                // reset action cooldown
                threeSec = 0.0f;

                // we can try to do something in three seconds
                threeSecAttempt = false;

                // attack left
                if (actionChance < 0.50f)
                {
                    manuever = 2;
                    gameObject.transform.position = new Vector3(-0.35f, 1.0f, 1.0f);
                }

                // attack right
                else if (0.51f < actionChance && actionChance < 0.80f)
                {
                    manuever = 2;
                    gameObject.transform.position = new Vector3(0.35f, 1.0f, 1.0f);
                }

                // attack sweep
                else
                {
                    manuever = 2;
                    gameObject.transform.position = new Vector3(0.35f, 0.0f, 0.7f);
                }
            }

            // should we ever get to five seconds, definetly do an action
            if (5.0f < threeSec)
            {
                // reset action cooldown
                threeSec = 0.0f;

                // we can try to do something in three seconds
                threeSecAttempt = false;

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
            gameObject.transform.position = new Vector3(0.0f, -0.1f, -0.3f);
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

            */
    }
}
