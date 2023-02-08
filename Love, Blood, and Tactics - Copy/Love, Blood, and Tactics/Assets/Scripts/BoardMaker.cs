using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoardMaker : MonoBehaviour
{
    public GameObject tile;

    public Vector2 boardDimensions = new Vector2(10, 20);

    public GameObject[,] board;

    // Start is called before the first frame update
    void Start()
    {
        // set our board array size based on dimensions
        board = new GameObject[((int)boardDimensions.x),((int)boardDimensions.y)];

        // make board from default tiles
        for (int x = 0; x < boardDimensions.x; x++)
        {
            for (int y = 0; y < boardDimensions.y; y++)
            {
                // make and move
                GameObject t = Instantiate(tile);
                t.GetComponent<Tile>().occupyable = true;
                t.transform.position = new Vector3(x, 0, y);

                // save to the array for reference
                board[x, y] = t;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
