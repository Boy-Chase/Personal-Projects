using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // amount of health at start
    public int health = 3;

    // invincibility frames
    public int iFrames = 1000;

    // runs damage in update
    bool collide = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        iFrames--;

        // player can be hurt
        if (iFrames < 0 && collide)
        {
            // decrement health
            health--;

            // reset iFrames
            iFrames = 1000;
        }
        // if player has iFrames, collision cannot occur
        else
        {
            collide = false;
        }
    }

    // called in harmful
    public void dealDamage()
    {
        collide = true;
    }
}
