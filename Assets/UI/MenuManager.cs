using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject mainMenuObject;
    public GameObject CampaginMenuObject;
    public GameObject onlineMenuObject;
    public GameObject settingMenuObject;
    public GameObject upgradeMenuObject;
    public GameObject sub_menuObject;
    
    // Start is called before the first frame update

    public void hideMainElement()
    {
        GameObject tittle = mainMenuObject.transform.GetChild(0).gameObject;
        GameObject bgv = uiObject.transform.GetChild(0).gameObject;
        tittle.SetActive(false);
        bgv.SetActive(false);
    }
    public void displaySubMenu(string whichButton)
    {
        sub_menuObject.SetActive(true);
        foreach(Transform child in sub_menuObject.transform)
        {
            Debug.Log(child.gameObject.name);
            if (child.gameObject.name == whichButton)
            {
                
                child.gameObject.SetActive(true);

            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    public void ClickCampaign()
    {
        hideMainElement();
        displaySubMenu("Campaign_sub");
        CampaginMenuObject.SetActive(true);
    }
    public void clickOnline()
    {
        displaySubMenu("Online_sub");
    }
    public void ClickSetting()
    {
        mainMenuObject.SetActive(false);
        settingMenuObject.SetActive(true);
    }

    public void ClickUpgrade()
    {
        SceneManager.LoadScene("shoppingPage");
    }

    public void ClickHome()
    {
        GameObject tittle = mainMenuObject.transform.GetChild(0).gameObject;
        GameObject bgv = uiObject.transform.GetChild(0).gameObject;
        tittle.SetActive(true);
        bgv.SetActive(true);
        CampaginMenuObject.SetActive(false);
        sub_menuObject.SetActive(false);
        upgradeMenuObject.SetActive(false);
    }

    public void ClickRaceMode()
    {
        SceneManager.LoadScene("shoppingPage");
    }

    public void ClickCombatMode()
    {
        SceneManager.LoadScene("shoppingPage");
    }


    public void ClickQuit()
    {
        Application.Quit();
    }
}
