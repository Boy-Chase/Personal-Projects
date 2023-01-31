using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopAndInventory : MonoBehaviour
{
    public List<string> inventory = new List<string>();
    public int funds = PlayerPrefs.GetInt("score");
    public Text fundsText;

    // Start is called before the first frame update
    void Start()
    {
        fundsText.text = funds.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
