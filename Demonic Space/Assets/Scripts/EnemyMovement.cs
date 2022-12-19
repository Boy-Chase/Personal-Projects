using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Player;

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

        // set Z to the Player's
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Player.transform.position.z + 15);

        // if cooldown is greater than sec, fire a bullet
        if (5.0f < shootCooldown)
        {
            Instantiate(bullet);
            bullet.GetComponent<Bullet>().playerMade = false;
            bullet.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 1);
            shootCooldown = 0.0f;
        }
    }
}
