using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class AircraftInformationPanel : MonoBehaviour, IPointerClickHandler
{

    public GameObject missilePanel;
    public GameObject missileInfomationPanel;
    public Button purchase;
    //public Text labelPrefab;

    private void Start()
    {
        purchase.onClick.AddListener(OnPurchaseClick);
    }

    private void OnPurchaseClick() {
        GameObject clickedObj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        if (clickedObj != null) {
            disableAll();
            missilePanel.SetActive(true);
        }
    }
    private void disableAll()
    {
        List<GameObject> objectList = new List<GameObject>();
        objectList.Add(missilePanel);
        objectList.Add(missileInfomationPanel);
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

    public void OnPointerClick(PointerEventData eventData)
    {
        disableAll();
        missileInfomationPanel.SetActive(true);
        disableAllMissileInfo();


        // Get the GameObject that was clicked on
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

        // Get the Image component of the clicked GameObject
        Image clickedImage = clickedObject.GetComponent<Image>();

        // Check if an Image component was found
        if (clickedImage != null)
        {
            activeMissile(clickedImage);
        }
        else
        {
            Debug.Log("No Image component was found on the clicked GameObject.");
        }





    }

    private void disableAllMissileInfo() {
        for (int i = 0; i < missileInfomationPanel.transform.childCount; i++)
        {
            
            GameObject childObject = missileInfomationPanel.transform.GetChild(i).gameObject;
            if(childObject.name != "PurchaseButton")
                childObject.SetActive(false);
        }
    }

    private void activeMINFO(string name) {
      
        for (int i = 0; i < missileInfomationPanel.transform.childCount; i++)
        {
            GameObject childObject = missileInfomationPanel.transform.GetChild(i).gameObject;

            if (childObject.name == name)
                childObject.SetActive(true);
        }

    }
    private void activeMissile(Image clickedImage) {
        if (clickedImage.name == "Aircraft1")
        {
            activeMINFO("AircraftInfo1");
        }
        else if (clickedImage.name == "Aircraft2")
        {
            activeMINFO("AircraftInfo2");
        }
        else if (clickedImage.name == "Aircraft3")
        {
            activeMINFO("AircraftInfo3");
        }
        else if (clickedImage.name == "Aircraft4")
        {
            activeMINFO("AircraftInfo4");
        }
        else if (clickedImage.name == "Aircraft5")
        {
            activeMINFO("AircraftInfo5");
        }
        else if (clickedImage.name == "Aircraft6")
        {
            activeMINFO("AircraftInfo6");
        }
    }

}

