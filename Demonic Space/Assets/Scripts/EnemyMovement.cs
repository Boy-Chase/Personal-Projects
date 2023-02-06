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
    
    public float health;

    // SFX
    public AudioClip shootSFX;
    public AudioClip hitSFX;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "boss")
        {
            health = 70.0f;
        }
        else if (gameObject.tag == "follower")
        {
            health = 15.0f;
        }
        else
        {
            health = 10.0f;
        }

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

        if (!Player.GetComponent<Player>().demonTimeActive)
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
                gameObject.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 2, Camera.transform.position.z + 25);
            }

            // if a boss class enemy, move like this
            if (gameObject.tag == "boss")
            {
                // set position based on camera
                gameObject.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 2, Camera.transform.position.z + 30);

                // increment cooldown AGAIN
                shootCooldown += Time.deltaTime;
            }
        }

        // if cooldown is greater than sec, fire a bullet(s)
        if (4.0f < shootCooldown)
        {
            AudioSource.PlayClipAtPoint(shootSFX, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 25));

            if (gameObject.tag == "boss")
            {
                Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 1), new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
                bullet.GetComponent<Bullet>().playerMade = false;

                Instantiate(bullet, new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y - 2, gameObject.transform.position.z - 1), new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
                bullet.GetComponent<Bullet>().playerMade = false;

                Instantiate(bullet, new Vector3(gameObject.transform.position.x - 2, gameObject.transform.position.y + 2, gameObject.transform.position.z - 1), new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
                bullet.GetComponent<Bullet>().playerMade = false;

                Instantiate(bullet, new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y - 2, gameObject.transform.position.z - 1), new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
                bullet.GetComponent<Bullet>().playerMade = false;

                Instantiate(bullet, new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y + 2, gameObject.transform.position.z - 1), new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
                bullet.GetComponent<Bullet>().playerMade = false;
            }
            else
            {
                Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 1), new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
                bullet.GetComponent<Bullet>().playerMade = false;
            }
            shootCooldown = 0.0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "laser")
        {
            health--;
        }

        if (other.gameObject.tag == "bullet")
        {
            if (other.GetComponent<Bullet>().playerMade)
            {
                // increment score 
                Player.GetComponent<Player>().score++;

                // increment DT
                Player.GetComponent<Player>().demonTimeIncrementer++;
            }

            // subtract health + destroy bullet
            if (other.tag == "bullet" && other.gameObject.GetComponent<Bullet>().playerMade)
            {
                health -= Player.GetComponent<Player>().damage;
                Destroy(other.gameObject);
            }

            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(hitSFX, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 15));

                Destroy(gameObject);

                // increment score 
                Player.GetComponent<Player>().score++;
                Player.GetComponent<Player>().score++;
                Player.GetComponent<Player>().score++;


                // increment DT
                Player.GetComponent<Player>().demonTimeIncrementer++;
                Player.GetComponent<Player>().demonTimeIncrementer++;
                Player.GetComponent<Player>().demonTimeIncrementer++;
            }
        }
    }
}
