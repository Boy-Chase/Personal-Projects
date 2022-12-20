using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Player;

    // what we're making
    public List<GameObject> type = new List<GameObject>();

    // where 
    public List<Vector3> position = new List<Vector3>();

    // at what point of player progression
    public List<float> playerZ = new List<float>();

    int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        index = 1000;

        foreach(float f in playerZ)
        {
            // if player has progressed to its spawn point
            if (f < Player.transform.position.z)
            {
                // get the index 
                index = playerZ.IndexOf(f);

                // spawn the item
                Instantiate(type[index], position[index], new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 1));
            }
        }

        // then, remove it from lists
        if(index != 1000)
        {
            type.RemoveAt(index);
            position.RemoveAt(index);
            playerZ.RemoveAt(index);
        }
    }
}
