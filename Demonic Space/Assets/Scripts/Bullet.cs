using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool playerMade = true;

    // Update is called once per frame
    void Update()
    {
        if (playerMade)
        {
            // move the bullet forward
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 15.0f * Time.deltaTime);
        }
        else
        {
            // move the bullet backward
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 15.0f * Time.deltaTime);
        }
    }
}
