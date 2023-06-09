using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    private Button[] buttons;
    public GameObject missilePanel;
    public GameObject missileInformationPanel;
    public GameObject aircraftPanel;
    public GameObject aircraftInformationPanel;
    public GameObject mainPage;
    public GameObject shopPage;
    private void disableAll() {
        List<GameObject> objectList = new List<GameObject>();
        objectList.Add(missilePanel);
        objectList.Add(missileInformationPanel);
        objectList.Add(aircraftPanel);
        objectList.Add(aircraftInformationPanel);
        foreach (GameObject objs in objectList)
        {
            // Check if the object was found
            if (objs != null)
            {
                // Do something with the object, such as enabling it or accessing its components
                objs.SetActive(false);
            }
            else
            {
                // Display an error message if the object was not found
                Debug.LogError("Could not find object");
            }
        }

        try
        {
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");



            // loop through all clones and destroy them
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
        }
        catch (UnityException)
        {

        }

    }
    private void Start()
    {
        disableAll();
        aircraftPanel.SetActive(true);

        // Get all the Button components in the scene
        buttons = FindObjectsOfType<Button>();

        // Add a listener to each button to detect when it is clicked
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(OnPointerClick);
        }

    
    }

    private void OnPointerClick()
    {

        GameObject clickedObj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        // Get the GameObject that was clicked

        disableAll();

        if (clickedObj == null)
        {
            Debug.Log("Null");
        }
        else
        {
            // Check if the clicked object is button1
            if (clickedObj.name == "AircraftButton")
            {
                aircraftPanel.SetActive(true);
            }

            // Check if the clicked object is button2
            else if (clickedObj.name == "MissileButton")
            {
                Debug.Log("MissileButton clicked!");
                missilePanel.SetActive(true);
            }
            else if (clickedObj.name == "UpgradeButton")
            {
                Debug.Log("UpgradeButton clicked!");
            }
            else if (clickedObj.name == "BackButton")
            {

                shopPage.SetActive(false);
                mainPage.SetActive(true);
            }
            else
            {
                Debug.Log("None");
            }
        }

    }

   

  
}
