using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;

    public float shootCooldown;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // increment cooldown
        shootCooldown += Time.deltaTime;

        // if a static class enemy, move like this
        if (gameObject.tag == "static")
        {
            // set position based on camera
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Camera.transform.position.z + 25);
        }

        // if a follower class enemy, move like this
        if (gameObject.tag == "follower")
        {
            // set position based on camera
            gameObject.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z + 25);
        }

        // if cooldown is greater than sec, fire a bullet
        if (5.0f < shootCooldown)
        {
            Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 1), new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
            bullet.GetComponent<Bullet>().playerMade = false;
            shootCooldown = 0.0f;
        }
    }
}
