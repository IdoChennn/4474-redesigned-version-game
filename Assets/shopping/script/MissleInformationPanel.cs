using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class MissleInformationPanel : MonoBehaviour, IPointerClickHandler
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
        string temp = enginePowerComponent.text;
        float result = float.Parse(temp) + float.Parse(money);
        enginePowerComponent.text = result.ToString();
    }

    private void Start()
    {
        purchase.onClick.AddListener(OnPurchaseClick);
    }

    private void OnPurchaseClick()
    {
        GameObject clickedObj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        if (clickedObj != null)
        {
            disableAll();
            missilePanel.SetActive(true);
        }
    }


    private void disableAll(){
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

        try {
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");



            // loop through all clones and destroy them
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
        }
        catch (UnityException){ 

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
        Debug.Log("Button name: " + eventData.pointerPress.name);

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
        if (clickedImage.name == "Missile1")
        {
            activeMINFO("Missile1Info");
            updateManeuverability("20");
            updateMoney("-9900");
        }
        else if (clickedImage.name == "Missile2")
        {
            activeMINFO("Missile2Info");
            updateEngine("11");
            updateManeuverability("10");
        }
        else if (clickedImage.name == "Missile3")
        {
            activeMINFO("Missile3Info");
            updateEngine("8");
            updateManeuverability("9");
        }
        else if (clickedImage.name == "Missile4")
        {
            activeMINFO("Missile4Info");
            
            updateManeuverability("6");
        }
        else if (clickedImage.name == "Missile5")
        {
            activeMINFO("Missile5Info");
            
            updateManeuverability("29");
        }
        else if (clickedImage.name == "Missile6")
        {
            activeMINFO("Missile6Info");
            
            updateManeuverability("25");
        }
        else if (clickedImage.name == "Missile7")
        {
            activeMINFO("Missile7Info");
            
            updateManeuverability("20");
        }
        else if (clickedImage.name == "Missile8")
        {
            activeMINFO("Missile8Info");
            
            updateManeuverability("30");
        }
    }

}

