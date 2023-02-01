using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probe : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;

    public float shootCooldown;
    public GameObject bullet;

    public Vector2 relXY;

    // Start is called before the first frame update
    void Start()
    {
        // find our player + camera
        Player = GameObject.FindGameObjectWithTag("player");
        Camera = GameObject.FindGameObjectWithTag("MainCamera");

        shootCooldown = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Player.transform.position.x - 2, Player.transform.position.y, Player.transform.position.z - 2);

        // increment cooldown
        shootCooldown += Time.deltaTime;

        // if cooldown is greater than sec, fire a bullet(s)
        if (3.0f < shootCooldown)
        {
            Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 1), new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
            bullet.GetComponent<Bullet>().playerMade = true;

            shootCooldown = 0.0f;
        }
    }
}
