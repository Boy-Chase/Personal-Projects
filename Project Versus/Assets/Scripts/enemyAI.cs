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

    // one sec commitment lock
    public float oneSec = 0.0f;

    // odds of enemy moving
    public float actionChance;

    // has three second action been rolled
    public bool threeSecAttempt = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // reset stance
        if (1.0f < oneSec)
        {
            manuever = 0;
            gameObject.transform.position = new Vector3(0.0f, 1.0f, 1.0f);
            oneSec = 0.0f;
        }

        // add to timer if it hasn't been three seconds 
        threeSec += Time.deltaTime;

        oneSec += Time.deltaTime;

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
                    manuever = 1;
                    gameObject.transform.position = new Vector3(-0.45f, 1.0f, 1.0f);
                    oneSec = 0.0f;
                }

                // attack right
                else if (0.51f < actionChance && actionChance < 0.80f)
                {
                    manuever = 2;
                    gameObject.transform.position = new Vector3(0.45f, 1.0f, 1.0f);
                    oneSec = 0.0f;
                }

                // attack sweep
                else
                {
                    manuever = 3;
                    gameObject.transform.position = new Vector3(0.0f, 0.8f, 0.7f);
                    oneSec = 0.0f;
                }
            }
        }

        // should we ever get to five seconds, definetly do an action
        if (5.0f <= threeSec)
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
                oneSec = 0.0f;
            }

            // attack right
            else if (0.36f < actionChance && actionChance < 0.70f)
            {
                manuever = 2;
                gameObject.transform.position = new Vector3(0.35f, 1.0f, 1.0f);
                oneSec = 0.0f;
            }

            // attack sweep
            else
            {
                manuever = 2;
                gameObject.transform.position = new Vector3(0.0f, 1.0f, 0.7f);
                oneSec = 0.0f;
            }
        }

        // set for next frame comparison
        lastManuever = manuever;
    }
}
