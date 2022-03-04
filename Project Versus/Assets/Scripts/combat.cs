using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour
{
    // player + state + health
    public GameObject hero;
    public int hM;
    public int hHealth = 10000;

    // enemy + state + health
    public GameObject villain;
    public int vM;
    public int vHealth = 5;

    // meter status
    public int meter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checking current states        
        hM = hero.GetComponent<charCon>().manuever;
        vM = villain.GetComponent<enemyAI>().manuever;

        // enemy left attack damage
        if(vM == 1 && hM != 2)
        {
            hHealth--;
        }
        // sucessful left dodge
        else if (vM == 1 && hM == 2) 
        {
            meter++;
        }

        // enemy right attack damage
        if (vM == 2 && hM != 1)
        {
            hHealth--;
        }
        // successful right dodge
        else if (vM == 2 && hM == 1)
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
