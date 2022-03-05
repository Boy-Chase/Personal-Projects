using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vHealthUI : MonoBehaviour
{
    // what we get health and meter from
    public GameObject combatManager;

    // healths and meter text to appear on text boxes
    public Text vHealthText;

    // Start is called before the first frame update
    void Start()
    {
        // set each for frame one
        vHealthText.text = combatManager.GetComponent<combat>().vHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // update each one constantly
        vHealthText.text = combatManager.GetComponent<combat>().vHealth.ToString();
    }
}
