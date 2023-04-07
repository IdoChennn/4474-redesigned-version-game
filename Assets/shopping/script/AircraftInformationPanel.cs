using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class AircraftInformationPanel : MonoBehaviour, IPointerClickHandler
{

    public GameObject missilePanel;
    public GameObject missileInfomationPanel;
    public Button purchase;
    //public Text labelPrefab;
    public TextMeshProUGUI moneyComponent;
    public TextMeshProUGUI enginePowerComponent;
    public TextMeshProUGUI maneuverabilityComponent;
    public TextMeshProUGUI hpComponent;

    public void updateMoney(string money)
    {
        string temp = moneyComponent.text;
        float result = float.Parse(temp) + float.Parse(money);
        if (result <= 0)
        {
            result = 0;
        }
        moneyComponent.text = result.ToString();
    }
    public void updateEngine(string money)
    {
        string temp = enginePowerComponent.text;
        float result = float.Parse(temp) + float.Parse(money);
        enginePowerComponent.text = result.ToString();
    }
    public void updateManeuverability(string money)
    {
        string temp = maneuverabilityComponent.text;
        float result = float.Parse(temp) + float.Parse(money);
        maneuverabilityComponent.text = result.ToString();
    }
    public void updateHP(string money)
    {
        string temp = hpComponent.text;
        float result = float.Parse(temp) + float.Parse(money);
        hpComponent.text = result.ToString();
    }
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
            updateEngine("50");
            updateManeuverability("20");
            updateHP("10");
            updateMoney("-9900");
        }
        else if (clickedImage.name == "Aircraft2")
        {

            activeMINFO("AircraftInfo2");
            updateEngine("50");
            updateManeuverability("30");
            updateHP("15");
            updateMoney("-9900");
        }
        else if (clickedImage.name == "Aircraft3")
        {
            activeMINFO("AircraftInfo3");
            updateEngine("55");
            updateManeuverability("40");
            updateHP("20");
            updateMoney("-9900");
        }
        else if (clickedImage.name == "Aircraft4")
        {
            activeMINFO("AircraftInfo4");
            updateEngine("60");
            updateManeuverability("45");
            updateHP("15");
            updateMoney("-9900");
        }
        else if (clickedImage.name == "Aircraft5")
        {
            activeMINFO("AircraftInfo5");
            updateEngine("50");
            updateManeuverability("30");
            updateHP("15");
            updateMoney("-9900");
        }
        else if (clickedImage.name == "Aircraft6")
        {
            activeMINFO("AircraftInfo6");
            updateEngine("80");
            updateManeuverability("30");
            updateHP("10");
            updateMoney("-9900");
        }
    }

}

