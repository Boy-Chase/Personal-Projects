using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // current position of the ship
    public Vector3 position;

    // stores input as a 2D vector
    private Vector2 playerInput;

    // bullet prefab
    public GameObject bullet;

    // game camera
    public Camera myCamera;
    private List<Vector2> pastPositionsXY = new List<Vector2>();

    void Start()
    {
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
        // all bullets in this script are made by the Player (not an enemy)
        bullet.GetComponent<Bullet>().playerMade = true;

        // move the player forward
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 7.0f * Time.deltaTime);

        // key a (move left)
        if (playerInput.x < 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 4.0f * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        // key d (move right)
        if (playerInput.x > 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 4.0f * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        // key w (move up)
        if (playerInput.y > 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 4.0f * Time.deltaTime, gameObject.transform.position.z);
        }

        // key s (move down)
        if (playerInput.y < 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 4.0f * Time.deltaTime, gameObject.transform.position.z);
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

        // move camera
        myCamera.transform.position = new Vector3(pastPositionsXY[0].x, pastPositionsXY[0].y, position.z - 5.0f);
    }

    // updates the input vector
    public void OnAction(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        
    }
}