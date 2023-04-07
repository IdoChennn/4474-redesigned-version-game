using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnginePowerMinus : MonoBehaviour
{
    UpgradeManager upgradeManager;
    Button thisButton;
    Image thisImage;
    hoverButton thisHover;
    // Start is called before the first frame update
    void Start()
    {
        upgradeManager = GameObject.FindGameObjectWithTag("UpdateManager").GetComponent<UpgradeManager>();
        thisButton = GetComponent<Button>();
        thisImage = GetComponent<Image>();
        thisHover = GetComponent<hoverButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (upgradeManager.GetEnginePowerLevel() <= 0)
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
