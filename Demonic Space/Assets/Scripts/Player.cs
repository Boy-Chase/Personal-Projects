using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // health + score + damage output + level of the player + where they finish
    public int health;
    public int score;
    public int level;
    public int levelFinish;
    public float damage;

    // inventory related variables
    public string inventory;
    private List<GameObject> probes = new List<GameObject>();
    public GameObject probe;
    public GameObject shield;
    public int ps;
    public float ts;
    public float ss;

    // demon time variables
    public bool demonTimeActive;
    public int demonTimeUses;
    private float demonTimeTimer;
    public int demonTimeIncrementer;

    // roll variables
    public float iFrames;
    private float startLock;
    public float rollTime;
    public string rollDir;
    public Quaternion rot;

    // shield variables
    public bool shieldOut;
    public float sTimer;

    // current position of the ship
    public Vector3 position;

    // stores input as a 2D vector
    public Vector2 playerInput;

    // bullet prefab
    public GameObject bullet;

    // game camera 
    public Camera myCamera;
    private List<Vector2> pastPositionsXY = new List<Vector2>();

    // game background + stars
    public GameObject backGround;
    public GameObject stars;

    // sound
    // from: https://omegaosg.itch.io/gameboy-sfx-pack
    public AudioClip shootSFX;
    public AudioClip demonTimeSFX;
    public AudioClip hurtSFX;
    public AudioClip healthSFX;
    public AudioClip rollSFX;

    void Start()
    {
        // get player inventory
        inventory = PlayerPrefs.GetString("inventory");

        // set roations
        gameObject.transform.Rotate(0, 90, 0);
        rot = gameObject.transform.rotation;

        // set player level starting variable values
        health = 3;
        score = 0;
        iFrames = 3.0f;
        startLock = 3.0f;
        rollTime = 2.0f;
        damage = 1.0f;
        level = PlayerPrefs.GetInt("level", 4);

        // set where this level will end
        if (level == 4)
        {
            levelFinish = 550;
        }
        else if (level == 5)
        {
            levelFinish = 850;
        }
        else if (level == 6)
        {
            levelFinish = 1600;
        }

        // set demon time variables
        demonTimeActive = false;
        demonTimeUses = 0;
        demonTimeTimer = 0.0f;
        demonTimeIncrementer = 0;

        // default positions
        for (int x = 0; x < 100; x++)
        {
            pastPositionsXY.Add(new Vector2(0.0f, 0.0f));
        }

        // all bullets in this script are made by the Player (not an enemy)
        bullet.GetComponent<Bullet>().playerMade = true;

        // probe incrementer
        ps = 0;

        // thruster incrementer
        ts = 1.0f;

        // shield cooldown incrementer
        ss = 20.0f;
        sTimer = 20.0f;

        // load in inventory 
        foreach (char i in inventory)
        {
            // blaster upgrade increases damage
            if (i == 'b')
            {
                damage += 0.1f;
            }
            // thruster upgrade decreases cooldown
            if (i == 't')
            {
                ts += 0.1f;
            }
            // shield upgrades load in
            if (i == 's')
            {
                ss -= 2.0f;
            }
            // attack probes
            if (i == 'p')
            {
                // make one
                GameObject p = Instantiate(probe);

                // give it a position relative to player
                if (ps == 0)
                {
                    p.GetComponent<Probe>().relXY = new Vector2(-2.5f, 0);
                }
                else if (ps == 1)
                {
                    p.GetComponent<Probe>().relXY = new Vector2(2.5f, 0);
                }
                else if (ps == 2)
                {
                    p.GetComponent<Probe>().relXY = new Vector2(0, 2.5f);
                }
                else if (ps == 3)
                {
                    p.GetComponent<Probe>().relXY = new Vector2(0, -2.5f);
                }
                else if (ps == 4)
                {
                    p.GetComponent<Probe>().relXY = new Vector2(-2.5f, -2.5f);
                }
                else if (ps == 5)
                {
                    p.GetComponent<Probe>().relXY = new Vector2(-2.5f, 2.5f);
                }
                else if (ps == 6)
                {
                    p.GetComponent<Probe>().relXY = new Vector2(2.5f, 2.5f);
                }
                else if (ps == 7)
                {
                    p.GetComponent<Probe>().relXY = new Vector2(2.5f, -2.5f);
                }

                // add it to list + increment
                probes.Add(p);
                ps++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // for every probe the player has
        foreach(GameObject p in probes)
        {
            // updates probe positions
            p.gameObject.transform.position = new Vector3(gameObject.transform.position.x + p.GetComponent<Probe>().relXY.x, gameObject.transform.position.y + p.GetComponent<Probe>().relXY.y, gameObject.transform.position.z - 2);
        }

        // manage shield
        if (ss != 20.0f && !shieldOut)
        {
            sTimer -= Time.deltaTime;

            if (sTimer < 0)
            {
                // make one
                GameObject s = Instantiate(shield);
                shieldOut = true;
            }
        }

        // update all timers
        iFrames -= Time.deltaTime;
        startLock -= Time.deltaTime;
        if (demonTimeActive)
        {
            demonTimeTimer += Time.deltaTime;
        }

        // if DT time end, end DT
        if (6.66f <= demonTimeTimer)
        {
            demonTimeActive = false;
            demonTimeTimer = 0.0f;
            stars.GetComponent<ParticleSystem>().Play();
        }

        // all bullets in this script are made by the Player (not an enemy)
        bullet.GetComponent<Bullet>().playerMade = true;

        // DT use check
        if (50 <= demonTimeIncrementer)
        {
            demonTimeUses++;
            demonTimeIncrementer -= 50;
        }

        if (!demonTimeActive)
        {
            // move the player forward
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 7.0f * Time.deltaTime);
        }

        if (startLock < 0.0f)
        {
            // key a (move left)
            if (playerInput.x < 0 && -7.0f < gameObject.transform.position.x)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 8.0f * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
            }

            // key d (move right)
            if (playerInput.x > 0 && gameObject.transform.position.x < 7.0f)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 8.0f * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
            }

            // key w (move up)
            if (playerInput.y > 0 && gameObject.transform.position.y < 7.0f)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 8.0f * Time.deltaTime, gameObject.transform.position.z);
            }

            // key s (move down)
            if (playerInput.y < 0 && -7.0f < gameObject.transform.position.y)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 8.0f * Time.deltaTime, gameObject.transform.position.z);
            }

            // start roll
            if (Input.GetMouseButtonDown(1) && rollDir == "" && rollTime < -3.0f)
            {
                if (playerInput.y < 0)
                {
                    AudioSource.PlayClipAtPoint(rollSFX, gameObject.transform.position);
                    rollTime = 2.0f;
                    rollDir = "down";
                }
                else if (playerInput.y > 0)
                {
                    AudioSource.PlayClipAtPoint(rollSFX, gameObject.transform.position);
                    rollTime = 2.0f;
                    rollDir = "up";
                }
                else if (playerInput.x < 0)
                {
                    AudioSource.PlayClipAtPoint(rollSFX, gameObject.transform.position);
                    rollTime = 2.0f;
                    rollDir = "left";
                }
                else if (playerInput.x > 0)
                {
                    AudioSource.PlayClipAtPoint(rollSFX, gameObject.transform.position);
                    rollTime = 2.0f;
                    rollDir = "right";
                }
            }

            // roll
            if (0.0f < rollTime)
            {
                rollTime -= Time.deltaTime;

                if (rollDir == "down")
                {
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z + 110f * Time.deltaTime);
                }
                else if (rollDir == "up")
                {
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z - 110f * Time.deltaTime);
                }
                else if (rollDir == "left")
                {
                    gameObject.transform.Rotate(-(gameObject.transform.rotation.z + 110f * Time.deltaTime), 0, 0);
                }
                else if (rollDir == "right")
                {
                    gameObject.transform.Rotate(gameObject.transform.rotation.z + 380f * Time.deltaTime, 0, 0);
                }
            }

            // if roll not happening, set rotation
            if (rollTime < 0.0f)
            {
                rollTime -= Time.deltaTime * ts;
                gameObject.transform.rotation = rot;
                rollDir = "";
            }

            // left click check
            if (Input.GetMouseButtonDown(0))
            {
                AudioSource.PlayClipAtPoint(shootSFX, gameObject.transform.position);

                // make bullets
                Instantiate(bullet, new Vector3(gameObject.transform.position.x - 0.75f, gameObject.transform.position.y, gameObject.transform.position.z + 0.5f), new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
                Instantiate(bullet, new Vector3(gameObject.transform.position.x + 0.75f, gameObject.transform.position.y, gameObject.transform.position.z + 0.5f), new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
            }                 

            // save ship position
            position = gameObject.transform.position;

            // move camera + background + stars
            myCamera.transform.position = new Vector3(pastPositionsXY[0].x, pastPositionsXY[0].y + 2, position.z - 8.5f);
            backGround.transform.position = new Vector3(pastPositionsXY[0].x, pastPositionsXY[0].y, position.z + 30.0f);
            stars.transform.position = new Vector3(pastPositionsXY[0].x, pastPositionsXY[0].y, position.z + 5.0f);

            // update list
            pastPositionsXY.Add(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
            pastPositionsXY.RemoveAt(0);

            // win condition
            if (/*1600.0f*/ levelFinish < gameObject.transform.position.z)
            {
                level++;
                score += health * 5;
                PlayerPrefs.SetString("inventory", inventory);
                PlayerPrefs.SetInt("score", score);
                PlayerPrefs.SetInt("level", level);
                SceneManager.LoadScene(3);
            }
        }
    }
    
    // updates the input vector
    public void OnAction(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }

    // updates the input vector
    public void OnDemonic(InputValue value)
    {
        if (0 < demonTimeUses)
        {
            AudioSource.PlayClipAtPoint(demonTimeSFX, gameObject.transform.position);
            demonTimeUses--;
            demonTimeActive = true;
            stars.GetComponent<ParticleSystem>().Pause();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (((other.tag == "bullet" && !other.gameObject.GetComponent<Bullet>().playerMade) || other.tag == "follower" || other.tag == "static" || other.tag == "boss" || other.tag == "asteroid" || other.tag == "ring") && iFrames < 0 && rollTime < 0)
        {
            AudioSource.PlayClipAtPoint(hurtSFX, gameObject.transform.position);

            health--;
            iFrames = 3.0f;
            Destroy(other.gameObject);

            if (health <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }

        if (other.tag == "health")
        {
            AudioSource.PlayClipAtPoint(healthSFX, gameObject.transform.position);

            health++;
            Destroy(other.gameObject);
        }
    }
}
