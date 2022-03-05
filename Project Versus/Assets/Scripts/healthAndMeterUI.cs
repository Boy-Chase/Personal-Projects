using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthAndMeterUI : MonoBehaviour
{
    // what we get health and meter from
    public GameObject combatManager;

    // healths and meter text to appear on text boxes
    public Text hHealthT;
    public Text vHealthT;
    public Text meterT;

    // Start is called before the first frame update
    void Start()
    {
        // set each for frame one
        hHealthT.text = combatManager.GetComponent<combat>().hHealth.ToString();
        vHealthT.text = combatManager.GetComponent<combat>().vHealth.ToString();
        meterT.text = combatManager.GetComponent<combat>().meter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // update each one constantly
        hHealthT.text = combatManager.GetComponent<combat>().hHealth.ToString();
        vHealthT.text = combatManager.GetComponent<combat>().vHealth.ToString();
        meterT.text = combatManager.GetComponent<combat>().meter.ToString();
    }
}
