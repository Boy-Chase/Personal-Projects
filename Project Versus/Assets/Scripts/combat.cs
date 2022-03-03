using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour
{
    // player + state + health
    public GameObject hero;
    public int hM;
    private int hHealth = 10;

    // enemy + state + health
    public GameObject villain;
    public int vM;
    private int vHealth = 10;

    // meter status
    int meter = 0;

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
    }
}
