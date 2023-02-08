using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject boardMaker;

    // Start is called before the first frame update
    void Start()
    {
        // get references
        boardMaker = GameObject.FindGameObjectWithTag("BM");

        // set our camera positions
        Vector2 bmd = boardMaker.GetComponent<BoardMaker>().boardDimensions; 
        gameObject.transform.position = new Vector3(bmd.x/2 - 0.5f, Mathf.Sqrt(bmd.x * bmd.x + bmd.y * bmd.y) / 2, bmd.y/2 - 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
