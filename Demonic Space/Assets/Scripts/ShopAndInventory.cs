using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopAndInventory : MonoBehaviour
{
    public int funds = 0;
    public List<string> inventory = new List<string>();
    public Text fundsText;

    // Start is called before the first frame update
    void Start()
    {
        funds = PlayerPrefs.GetInt("score");
        fundsText.text = funds.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        fundsText.text = funds.ToString();
    }

    public void buyProbe()
    {
        if (100 < funds)
        {
            funds -= 100;
            inventory.Add("probe");
        }
    }

    public void buyShield()
    {
        if (50 < funds)
        {
            funds -= 100;
            inventory.Add("shield");
        }
    }

    public void buyBlaster()
    {
        if (10 < funds)
        {
            funds -= 100;
            inventory.Add("blaster");
        }
    }
    public void buyThruster()
    {
        if (10 < funds)
        {
            funds -= 100;
            inventory.Add("thruster");
        }
    }

    public void buyBeam()
    {
        if (200 < funds)
        {
            funds -= 100;
            inventory.Add("beam");
        }
    }

    public void ToLevel()
    {
        SceneManager.LoadScene(2);
    }
}
