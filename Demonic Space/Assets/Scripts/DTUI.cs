using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DTUI : MonoBehaviour
{
    // what we get health and meter from
    public GameObject Player;

    // healths and meter text to appear on text boxes
    public Text demonTimeStatText;

    // Start is called before the first frame update
    void Start()
    {
        // set for frame one
        demonTimeStatText.text = Player.GetComponent<Player>().demonTimeUses.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // update each one constantly
        demonTimeStatText.text = Player.GetComponent<Player>().demonTimeUses.ToString();
    }
}
