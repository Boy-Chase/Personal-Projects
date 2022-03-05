using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthAndMeterUI : MonoBehaviour
{
    // what we get health and meter from
    public GameObject combatManager;

    // healths and meter text to appear on text boxes
    public Text hHealthText;
    public Text vHealthText;
    public Text meterText;

    // Start is called before the first frame update
    void Start()
    {
        // set each for frame one
        hHealthText.text = combatManager.GetComponent<combat>().hHealth.ToString();
        vHealthText.text = combatManager.GetComponent<combat>().vHealth.ToString();
        meterText.text = combatManager.GetComponent<combat>().meter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // update each one constantly
        hHealthText.text = combatManager.GetComponent<combat>().hHealth.ToString();
        vHealthText.text = combatManager.GetComponent<combat>().vHealth.ToString();
        meterText.text = combatManager.GetComponent<combat>().meter.ToString();
    }
}
