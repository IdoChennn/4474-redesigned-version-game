using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class DashboardController : MonoBehaviour
{
    private Button[] buttons;
    public GameObject hangerPage;
    public GameObject shopPage;
    public GameObject mainPage;
    public GameObject aircraftPage;


    private void disableAll()
    {
        List<GameObject> objectList = new List<GameObject>();
        objectList.Add(hangerPage);
        objectList.Add(shopPage);
        objectList.Add(mainPage);

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

    }
    private void Start()
    {
        disableAll();
        mainPage.SetActive(true);
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
            if (clickedObj.name == "Shop")
            {
                shopPage.SetActive(true);
                aircraftPage.SetActive(true);

            }

            // Check if the clicked object is button2
            else if (clickedObj.name == "Hanger")
            {
                hangerPage.SetActive(true);
            }
            else if (clickedObj.name == "StartGame")
            {
                SceneManager.LoadScene("CombatScene");
            }
            else
            {
                Debug.Log("None");
            }
        }

    }




}
