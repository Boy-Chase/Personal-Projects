using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool playerMade = false;
    public float rotate;
    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // after 10 sec, destroy bullet
        timer += Time.deltaTime;
        if(10.0f < timer)
        {
            Destroy(gameObject);
        }

        // rotate it
        gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z + 150f * Time.deltaTime);

        if (playerMade)
        {
            // move the bullet forward
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 20.0f * Time.deltaTime);
        }
        else
        {
            // move the bullet backward
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 20.0f * Time.deltaTime);
        }
    }
}
