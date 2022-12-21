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
        gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, rotate + 200 * Time.deltaTime, 1);
        rotate = gameObject.transform.rotation.z;

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
