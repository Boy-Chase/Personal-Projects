using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // health of the player
    public int health;

    // current position of the ship
    public Vector3 position;

    // stores input as a 2D vector
    public Vector2 playerInput;

    // bullet prefab
    public GameObject bullet;

    // game camera
    public Camera myCamera;
    private List<Vector2> pastPositionsXY = new List<Vector2>();

    // game background
    public GameObject backGround;

    public float iFrames;
    private float startLock;
    public float rollTime;
    private float subtract;
    public string rollDir;
    public Quaternion rot;

    void Start()
    {
        gameObject.transform.Rotate(0, 90, 0);
        rot = gameObject.transform.rotation;

        // set health + invincibilty + control lock
        health = 3;
        iFrames = 3.0f;
        startLock = 3.0f;
        rollTime = 2.0f;

        // default positions
        for (int x = 0; x < 100; x++)
        {
            pastPositionsXY.Add(new Vector2(0.0f, 0.0f));
        }

        // all bullets in this script are made by the Player (not an enemy)
        bullet.GetComponent<Bullet>().playerMade = true;
    }

    // Update is called once per frame
    void Update()
    {
        iFrames -= Time.deltaTime;
        startLock -= Time.deltaTime;

        // all bullets in this script are made by the Player (not an enemy)
        bullet.GetComponent<Bullet>().playerMade = true;

        // move the player forward
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 7.0f * Time.deltaTime);

        if (startLock < 0.0f)
        {
            // key a (move left)
            if (playerInput.x < 0 && -5.0f < gameObject.transform.position.x)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 4.0f * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
            }

            // key d (move right)
            if (playerInput.x > 0 && gameObject.transform.position.x < 5.0f)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 4.0f * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
            }

            // key w (move up)
            if (playerInput.y > 0 && gameObject.transform.position.y < 5.0f)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 4.0f * Time.deltaTime, gameObject.transform.position.z);
            }

            // key s (move down)
            if (playerInput.y < 0 && -5.0f < gameObject.transform.position.y)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 4.0f * Time.deltaTime, gameObject.transform.position.z);
            }

            // start roll
            if (Input.GetMouseButtonDown(1) && rollDir == "")
            {
                if (playerInput.y < 0)
                {
                    rollTime = 2.0f;
                    subtract = Time.deltaTime;
                    rollDir = "down";
                }
                else if (playerInput.y > 0)
                {
                    rollTime = 2.0f;
                    subtract = Time.deltaTime;
                    rollDir = "up";
                }
                else if (playerInput.x < 0)
                {
                    rollTime = 2.0f;
                    subtract = Time.deltaTime;
                    rollDir = "left";
                }
                else if (playerInput.x > 0)
                {
                    rollTime = 2.0f;
                    subtract = Time.deltaTime;
                    rollDir = "right";
                }
            }

            // roll
            if (0.0f < rollTime)
            {
                rollTime -= subtract;

                if (rollDir == "down")
                {
                    Debug.Log(rollTime);
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z + 120f * subtract);
                }
                else if (rollDir == "up")
                {
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z - 120f * subtract);
                }
                else if (rollDir == "left")
                {
                    gameObject.transform.Rotate(gameObject.transform.rotation.z + 120f * subtract, 0, 0);
                }
                else if (rollDir == "right")
                {
                    gameObject.transform.Rotate(0, 0, gameObject.transform.rotation.z + 120f * subtract);
                }
            }

            // if roll not happening, set rotation
            if (rollTime < 0.0f)
            {
                gameObject.transform.rotation = rot;
                rollDir = "";
            }

            // left click check
            if (Input.GetMouseButtonDown(0))
            {
                // make bullets
                Instantiate(bullet, new Vector3(gameObject.transform.position.x - 0.75f, gameObject.transform.position.y, gameObject.transform.position.z + 0.5f), new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
                Instantiate(bullet, new Vector3(gameObject.transform.position.x + 0.75f, gameObject.transform.position.y, gameObject.transform.position.z + 0.5f), new Quaternion(gameObject.transform.rotation.x - 90, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
            }                 

            // save ship position
            position = gameObject.transform.position;

            // update list
            pastPositionsXY.Add(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));
            pastPositionsXY.RemoveAt(0);

            // move camera + background
            myCamera.transform.position = new Vector3(pastPositionsXY[0].x, pastPositionsXY[0].y, position.z - 5.0f);
            backGround.transform.position = new Vector3(pastPositionsXY[0].x, pastPositionsXY[0].y, position.z + 30.0f);
        }
    }
    
    // updates the input vector
    public void OnAction(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }

    void OnTriggerEnter(Collider other)
    {
        // if Player is touching card
        if (((other.tag == "bullet" && !other.gameObject.GetComponent<Bullet>().playerMade) || other.tag == "follower" || other.tag == "static" || other.tag == "asteroid") && iFrames < 0)
        {
            health--;
            iFrames = 3.0f;
            Destroy(other.gameObject);
        }
    }
}
