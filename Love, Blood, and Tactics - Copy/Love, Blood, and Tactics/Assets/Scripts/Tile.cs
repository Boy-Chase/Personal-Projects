using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour
{
    public List<Material> textures;

    // can it be moved to
    public bool occupyable;

    // what type of ground this is
    public string terrain;

    // Start is called before the first frame update
    void Start()
    {
        occupyable = true;
        terrain = "ground";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
