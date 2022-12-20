using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;

    public float shootCooldown;
    public GameObject bullet;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;

        shootCooldown = 0.0f;

        // find our player + camera
        Player = GameObject.FindGameObjectWithTag("player");
        Camera = GameObject.FindGameObjectWithTag("MainCamera");

        // all bullets in this script are made by an enemy
        bullet.GetComponent<Bullet>().playerMade = false;
    }

    // Update is called once per frame
    void Update()
    {
        // all bullets in this script are made by an enemy
        bullet.GetComponent<Bullet>().playerMade = false;

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

    void OnTriggerEnter(Collider other)
    {
        // if Player is touching card
        if (other.tag == "bullet" && other.gameObject.GetComponent<Bullet>().playerMade)
        {
            health--;
            Destroy(other.gameObject);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
