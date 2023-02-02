using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopAndInventory : MonoBehaviour
{
    public int funds = 0;
    public string inventory;
    public Text fundsText;

    // Start is called before the first frame update
    void Start()
    {
        // get playerprefs
        funds = PlayerPrefs.GetInt("score");
        inventory = PlayerPrefs.GetString("inventory");

        // set initial funds ui
        fundsText.text = funds.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // keep amount of funds current
        fundsText.text = funds.ToString();
    }

    // button methods
    public void buyProbe()
    {
        if (20 < funds)
        {
            funds -= 20;
            inventory += "p";
        }
    }

    public void buyShield()
    {
        if (50 < funds)
        {
            funds -= 100;
            inventory += "s";
        }
    }

    public void buyBlaster()
    {
        if (10 < funds)
        {
            funds -= 100;
            inventory += "b";
        }
    }
    public void buyThruster()
    {
        if (10 < funds)
        {
            funds -= 100;
            inventory += "t";
        }
    }

    public void buyLaser()
    {
        if (200 < funds)
        {
            funds -= 100;
            inventory += "l";
        }
    }

    public void ToLevel()
    {
        PlayerPrefs.SetString("inventory", inventory);
        SceneManager.LoadScene(PlayerPrefs.GetInt("level", 4));
    }
}
