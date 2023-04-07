using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAdd : MonoBehaviour
{
    public float cost;
    GameObject upgradeManagerObject;
    UpgradeManager upgradeManager;
    Button thisButton;
    Image thisImage;
    hoverButton thisHover;
    // Start is called before the first frame update
    void Start()
    {
        upgradeManagerObject = GameObject.FindGameObjectWithTag("UpdateManager");
        upgradeManager = upgradeManagerObject.GetComponent<UpgradeManager>();
        thisButton = GetComponent<Button>();
        thisImage = GetComponent<Image>();
        thisHover = GetComponent<hoverButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (upgradeManager.GetMoney() < cost)
        {
            thisButton.enabled = false;
            thisImage.enabled = false;
            thisHover.enabled = false;
        }
        else
        {
            thisButton.enabled = true;
            thisImage.enabled = true;
            thisHover.enabled = true;
        }
    }
}
