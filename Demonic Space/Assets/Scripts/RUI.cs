using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RUI : MonoBehaviour
{
    // what we get health and meter from
    public GameObject Player;

    // healths and meter text to appear on text boxes
    public Text rollStatText;

    // Start is called before the first frame update
    void Start()
    {
        // set for frame one
        rollStatText.text = "Available";
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Player>().rollTime < -3.0f)
        {
            // update each one constantly
            rollStatText.text = "Available";
        }
        else
        {
            // update each one constantly
            rollStatText.text = "On Cooldown";
        }
    }
}
