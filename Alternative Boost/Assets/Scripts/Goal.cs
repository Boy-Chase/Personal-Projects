using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // runs on collision
    void OnCollisionEnter(Collision objectHit)
    {
        // if player makes, contact with this object, set won to true
        if (objectHit.gameObject.GetComponent<PlayerMovement>() != null)
        {
       
        }
    }
}
