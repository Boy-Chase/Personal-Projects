using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour
{
    // player + state + health
    public GameObject hero;
    public int hM;
    public float hTimer;
    public int hHealth = 10000;

    // enemy + state + health
    public GameObject villain;
    public int vM;
    public float vTimer;
    public int vHealth = 5;
    public float antT;

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

        // enemy left attack damage
        if (vM == 1 && hM != 2 && antT < vTimer)
        {
            hHealth--;
        }
        // sucessful left dodge
        else if (vM == 1 && hM == 2) 
        {
            meter++;
        }

        // enemy right attack damage
        if (vM == 2 && hM != 1 && antT < vTimer)
        {
            hHealth--;
        }
        // successful right dodge
        else if (vM == 2 && hM == 1)
        {
            meter++;
        }

        // enemy sweep attack damage
        if (vM == 3 && hM != 3 && antT < vTimer)
        {
            hHealth--;
        }
        // sucessful left dodge
        else if (vM == 3 && hM == 3)
        {
            meter++;
        }

        // protag attack attempt
        if (hM == 4 && 100 < meter)
        {
            meter -= 100;
            vHealth--;
        }
    }
}
