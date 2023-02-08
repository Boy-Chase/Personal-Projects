using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    public int health = 10;
    public int attack = 3;
    public int range = 3;
    public int movement = 5;

    public Vector2 position = new Vector2(0, 0);
    public bool selected = false;

    public GameObject boardMaker;
    public GameObject myTile;

    public Material notSelectedMat;
    public Material selectedMat;

    // Start is called before the first frame update
    void Start()
    {
        // get references
        boardMaker = GameObject.FindGameObjectWithTag("BM");

        // set starting character spaces
        for (int i = 0; i < 10; i++)
        {
            if (boardMaker.GetComponent<BoardMaker>().board[i, 0].GetComponent<Tile>().occupyable)
            {
                // default starting pile
                myTile = boardMaker.GetComponent<BoardMaker>().board[i, 0];
                position = new Vector2 (i, 0);
                gameObject.transform.position = new Vector3(myTile.transform.position.x, 0.5f, myTile.transform.position.z);
                myTile.GetComponent<Tile>().occupyable = false;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        gameObject.GetComponent<Renderer>().material = selectedMat;
        selected = true;
    }
}


