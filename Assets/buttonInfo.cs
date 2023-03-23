using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonInfo : MonoBehaviour
{
    public int itemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public GameObject shopManager;
    // Update is called once per frame
    void Update()
    {
        PriceTxt.text = "Price: $" + shopManager.GetComponent<shopManagerScript>().shopItems[2, itemID].ToString();
        QuantityTxt.text = shopManager.GetComponent<shopManagerScript>().shopItems[3, itemID].ToString();
    }
}
