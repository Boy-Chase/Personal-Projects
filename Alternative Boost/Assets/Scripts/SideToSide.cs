using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 200; i++)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(100.0f, 0.0f, 100.0f));
        }

        for (int i = 0; i < 200; i++)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-100.0f, 0.0f, -100.0f));
        }
    }
}
