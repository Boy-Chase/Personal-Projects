using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class charCon : MonoBehaviour
{
    // represents the current action of character
    // 0 = neutral
    // 1 = left dodge
    // 2 = right dodge
    // 3 = attack (does nothing if meter too low)
    public int manuever = 0;

    // amount of attack meter
    public int meter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
