using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject mainMenuObject;
    public GameObject playMenuObject;
    public GameObject onlineMenuObject;
    public GameObject settingMenuObject;
    public GameObject upgradeMenuObject;
    public GameObject sub_menuObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*    public void hideDisplayTittle(Boolean hideOrDisplay)
    {
        GameObject tittle = mainMenuObject.transform.GetChild(0).gameObject;
        tittle.SetActive(false);
    }*/
    public void ClickCampaign()
    {
        //mainMenuObject.SetActive(true);
        GameObject tittle = mainMenuObject.transform.GetChild(0).gameObject;
        GameObject bgv = uiObject.transform.GetChild(0).gameObject;
        tittle.SetActive(false);
        bgv.SetActive(false);
        
        sub_menuObject.SetActive(true);

        //titte = mainMenuObject.transform.Find("Tittle").gameObject;
        //titte.SetActive(false);
        playMenuObject.SetActive(true);
    }

    public void ClickSetting()
    {
        mainMenuObject.SetActive(false);
        settingMenuObject.SetActive(true);
    }

    public void ClickUpgrade()
    {
        //mainMenuObject.SetActive(false);
        //upgradeMenuObject.SetActive(true);
        SceneManager.LoadScene("shoppingPage");
    }

    public void ClickBack()
    {
        GameObject tittle = mainMenuObject.transform.GetChild(0).gameObject;
        GameObject bgv = uiObject.transform.GetChild(0).gameObject;
        tittle.SetActive(true);
        bgv.SetActive(true);
        //mainMenuObject.SetActive(true);
        playMenuObject.SetActive(false);
        sub_menuObject.SetActive(false);
       // howToPlayMenuObject.SetActive(false);
        upgradeMenuObject.SetActive(false);
    }

    public void ClickRaceMode()
    {
        SceneManager.LoadScene("PlaneRace");
    }

    public void ClickCombatMode()
    {
        SceneManager.LoadScene("CombatScene");
    }


    public void ClickQuit()
    {
        Application.Quit();
    }
}
