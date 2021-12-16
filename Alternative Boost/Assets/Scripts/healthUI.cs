using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    // the object we're getting health
    public GameObject player;

    // the level's goal
    public GameObject goal;

    // text to represent info above
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        // updates texts to be current
        healthText.text = player.GetComponentInChildren<Health>().health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // if goal reached, print that to UI
        if (goal.GetComponent<Goal>().won)
        {
            healthText.text = "WON !!";
        }
        else
        {
            // updates texts to be current
            healthText.text = player.GetComponentInChildren<Health>().health.ToString();
        }
    }
}
