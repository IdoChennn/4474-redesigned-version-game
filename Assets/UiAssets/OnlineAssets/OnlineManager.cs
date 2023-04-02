using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class OnlineManager : MonoBehaviour
{
    public Button StartGameButton;
    public Button RaceButton;
    public Button combatButton;
    public GameObject afterSelectWindow;
    void Start()
    {
        StartGameButton.interactable = false;
    }

    // Update is called once per frame
    public void enableStartButton()
    {
        StartGameButton.interactable = true;
    }

    public void afterSelect()
    {
        afterSelectWindow.SetActive(true);
    }

    public void goBackModeSelection()
    {
        afterSelectWindow.SetActive(false);
    }
    public void pressStart()
    {
        SceneManager.LoadScene("PlaneRace");
    }
}
