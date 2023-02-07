using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMaker : MonoBehaviour
{
    public GameObject tile;

    public Vector2 boardDimensions = new Vector2(10, 20);

    // Start is called before the first frame update
    void Start()
    {
        // make board from default tiles
        for (int x = 0; x < boardDimensions.x; x++)
        {
            for (int y = 0; y < boardDimensions.x; y++)
            {
                GameObject t = Instantiate(tile);
                t.transform.position = new Vector3(x, 0, y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
