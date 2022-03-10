using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour
{
    // player + state + health
    public GameObject hero;
    public int hM;
    public float hTimer;
    public int hHealth = 5;

    // NEW
    public int lasthM;

    // NEW
    public bool attack = false;

    // enemy + state + health
    public GameObject villain;
    public int vM;
    public float vTimer;
    public int vHealth = 15;
    public float antT;

    // NEW
    public int lastvM;

    // NEW
    public bool hurt = false;

    // meter status
    public int meter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // number doesn't change
        antT = villain.GetComponent<enemyAI>().antFrames;
    }

    // Update is called once per frame
    void Update()
    {
        // checking current states        
        hM = hero.GetComponent<charCon>().manuever;
        vM = villain.GetComponent<enemyAI>().manuever;

        // checking timers
        hTimer = hero.GetComponent<charCon>().timer;
        vTimer = villain.GetComponent<enemyAI>().threeSec;

        // NEW
        // villain returns to neutral
        if ( (lastvM == 1 || lastvM == 2 || lastvM == 3) && vM == 0 && hurt)
        {
            // if hurt, apply and reset
            hHealth--;
            hurt = false;
        }

        // villain returns to neutral
        if (lasthM == 4 && hM == 0 && attack)
        {
            // if hurt, apply and reset
            vHealth--;
            meter -= 250;
            attack = false;
        }

        // enemy left attack damage
        if (vM == 1 && hM != 2 && antT < vTimer)
        {
            hurt = true;
        }
        // sucessful left dodge
        else if (vM == 1 && hM == 2) 
        {
            meter++;
        }

        // enemy right attack damage
        if (vM == 2 && hM != 1 && antT < vTimer)
        {
            hurt = true;
        }
        // successful right dodge
        else if (vM == 2 && hM == 1)
        {
            meter++;
        }

        // enemy sweep attack damage
        if (vM == 3 && hM != 3 && antT < vTimer)
        {
            hurt = true;
        }
        // sucessful left dodge
        else if (vM == 3 && hM == 3)
        {
            meter++;
        }

        // protag attack attempt
        if (hM == 4 && 250 < meter)
        {
            attack = true;
        }

        // set hero's last manuever
        lasthM = hM;

        // set villain's last manuever
        lastvM = vM;
    }
}
