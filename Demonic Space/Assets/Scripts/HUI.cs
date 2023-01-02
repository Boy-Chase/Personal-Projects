using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUI : MonoBehaviour
{
    // what we get health and meter from
    public GameObject Player;

    // healths and meter text to appear on text boxes
    public Text healthStatText;

    // Start is called before the first frame update
    void Start()
    {
        // set for frame one
        healthStatText.text = Player.GetComponent<Player>().health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // update each one constantly
        healthStatText.text = Player.GetComponent<Player>().health.ToString();
    }
}
