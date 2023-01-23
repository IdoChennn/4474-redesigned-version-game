using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuObject;
    public GameObject playMenuObject;
    public GameObject howToPlayMenuObject;
    public GameObject upgradeMenuObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickPlay()
    {
        mainMenuObject.SetActive(false);
        playMenuObject.SetActive(true);
    }

    public void ClickHowToPlay()
    {
        mainMenuObject.SetActive(false);
        howToPlayMenuObject.SetActive(true);
    }

    public void ClickUpgrade()
    {
        mainMenuObject.SetActive(false);
        upgradeMenuObject.SetActive(true);
    }

    public void ClickBack()
    {
        mainMenuObject.SetActive(true);
        playMenuObject.SetActive(false);
        howToPlayMenuObject.SetActive(false);
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
