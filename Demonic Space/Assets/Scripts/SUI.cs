using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUI : MonoBehaviour
{
    // what we get health and meter from
    public GameObject Player;

    // healths and meter text to appear on text boxes
    public Text scoreStatText;

    // Start is called before the first frame update
    void Start()
    {
        // set for frame one
        scoreStatText.text = Player.GetComponent<Player>().score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // update each one constantly
        scoreStatText.text = Player.GetComponent<Player>().score.ToString();
    }
}
