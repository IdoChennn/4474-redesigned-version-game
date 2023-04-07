using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject CampaginMenuObject;
    public GameObject settingsMenuObject;
    public GameObject upgradeMenuObject;
    public GameObject homeMenuObject;
    public GameObject achievementMenuObject;

    public Button homeButton;
    public Button campaignButton;
    public Button upgradeButton;
    public Button settingsButton;
    public Button achievementButton;
    public List<GameObject> menuObjectList;
    public List<Button> buttonList;

    // Start is called before the first frame update

    private void Start()
    {
        //this order is very important do not touch
        menuObjectList.Add(homeMenuObject);         //0
        buttonList.Add(homeButton);
        menuObjectList.Add(CampaginMenuObject);     //1
        buttonList.Add(campaignButton);
        menuObjectList.Add(upgradeMenuObject);       //2
        buttonList.Add(upgradeButton);
        menuObjectList.Add(settingsMenuObject);     //3
        buttonList.Add(settingsButton);
        menuObjectList.Add(achievementMenuObject);  //4
        buttonList.Add(achievementButton);
    }

    /*
    public void DisplaySubMenu(string whichButton)
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
    */

    public void DisplayMenu(int menuOption)
    {
        foreach(GameObject menuObject in menuObjectList)
        {
            menuObject.SetActive(false);
        }
        menuObjectList[menuOption].SetActive(true);
        foreach(Button menuButton in buttonList)
        {
            if (menuButton != null)
                menuButton.interactable = true;
        }
        if (buttonList.Count != 0)
        {
            if (buttonList[menuOption] != null)
                buttonList[menuOption].interactable = false;
        }
    }

    public void ClickHome()
    {
        DisplayMenu(0);
    }

    public void ClickCampaign()
    {
        DisplayMenu(1);
    }
    public void ClickUpgrade()
    {
        DisplayMenu(2);
    }
    public void ClickSettings()
    {
        DisplayMenu(3);
    }
    public void ClickAchievement()
    {
        DisplayMenu(4);
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
