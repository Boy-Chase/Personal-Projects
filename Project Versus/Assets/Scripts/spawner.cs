using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;

    public GameObject currentEnemy;

    public int combatCount = 0;
    public int combatRound = 0;

    public int enemyHealth; 

    // Start is called before the first frame update
    void Start()
    {
        // how many rounds there will be
        combatCount = Random.Range(1, 5);

        // make enemy prefab + assign as villian in this script
        currentEnemy = Instantiate(enemy);
        this.GetComponent<combat>().villain = currentEnemy;

        this.GetComponent<combat>().villain.transform.position = new Vector3(0.0f, 1.31f, 1.0f);
        this.GetComponent<combat>().villain.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // runs while combat rounds have not concluded
        if (combatRound < combatCount) 
        {
            if (currentEnemy.GetComponent<enemyAI>().timeToDie)
            {
                // make enemy prefab + assign as villian in this script
                currentEnemy = Instantiate(enemy);
                this.GetComponent<combat>().villain = currentEnemy;

                this.GetComponent<combat>().villain.transform.position = new Vector3(0.0f, 1.31f, 1.0f);
                this.GetComponent<combat>().villain.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);

                // give player a health
                this.GetComponent<combat>().hHealth++;

                // on to next combat round
                combatRound++;
            }
        }
    }
}
