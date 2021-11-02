using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmful : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 3d distance formula
        if( Mathf.Sqrt((Mathf.Pow((player.transform.position.x - transform.position.x), 2f) + Mathf.Pow((player.transform.position.y - transform.position.y), 2f) + Mathf.Pow((player.transform.position.z - transform.position.z), 2f))) < 1.0f)
        {
            player.GetComponentInChildren<Health>().dealDamage();
        }
    }
}
