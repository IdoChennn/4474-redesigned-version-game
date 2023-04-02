using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuManager : MonoBehaviour
{
    public GameObject generalPageObject;
    public GameObject graphicsPageObject;
    public GameObject audioPageObject;
    public GameObject controlsPageObject;

    public Button generalButton;
    public Button graphicsButton;
    public Button audioButton;
    public Button controlsButton;

    public List<GameObject> pageObjectList;
    public List<Button> settingsButtonList;
    // Start is called before the first frame update
    void Start()
    {
        //the order is very impotant to do not touch
        pageObjectList.Add(generalPageObject);          //0
        settingsButtonList.Add(generalButton);
        pageObjectList.Add(graphicsPageObject);         //1
        settingsButtonList.Add(graphicsButton);
        pageObjectList.Add(audioPageObject);            //2
        settingsButtonList.Add(audioButton);
        pageObjectList.Add(controlsPageObject);         //3
        settingsButtonList.Add(controlsButton);
    }

    public void DisplayPage(int pageOption)
    {
        foreach (GameObject pageObject in pageObjectList)
        {
            pageObject.SetActive(false);
        }
        pageObjectList[pageOption].SetActive(true);
        foreach (Button menuButton in settingsButtonList)
        {
            menuButton.interactable = true;
        }
        settingsButtonList[pageOption].interactable = false;
    }

    public void ClickGeneralButton()
    {
        DisplayPage(0);
    }

    public void ClickGraphicsButton()
    {
        DisplayPage(1);
    }

    public void ClickAudioButton()
    {
        DisplayPage(2);
    }

    public void ClickControlsButton()
    {
        DisplayPage(3);
    }
}
